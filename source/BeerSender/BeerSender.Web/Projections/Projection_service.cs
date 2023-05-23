using System.Collections;
using BeerSender.Web.EventStore;
using BeerSender.Web.ReadStore;
using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.Projections;

public class Projection_service<TProjection> : BackgroundService
    where TProjection : Projection
{
    private const int Batch_size = 100;
    private readonly IServiceProvider _serviceProvider;

    public Projection_service(
        IServiceProvider serviceProvider
        )
    {
        _serviceProvider = serviceProvider;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var checkpoint = Get_checkpoint();

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            await using var event_context = scope.ServiceProvider.GetRequiredService<Event_context>();
            await using var read_context = scope.ServiceProvider.GetRequiredService<Read_context>();
            
            var projection = scope.ServiceProvider.GetRequiredService<TProjection>();

            var events = await Read_batch(event_context, checkpoint, projection.Relevant_events);

            await using var transaction = await read_context.Database.BeginTransactionAsync(stoppingToken);
            foreach (var @event in events)
            {
                checkpoint = projection.Project(@event);
            }

            Save_checkpoint(checkpoint, read_context);

            await read_context.SaveChangesAsync(stoppingToken);
            await transaction.CommitAsync(stoppingToken);
        }
    }

    private void Save_checkpoint(long checkpoint, Read_context read_context)
    {
        read_context.Checkpoints.Update(new Checkpoint
        {
            Name = typeof(TProjection).Name,
            Last_timestamp = checkpoint
        });
    }

    private async Task<IEnumerable<Event>> Read_batch(Event_context event_context, long checkpoint, Type[] relevant_events)
    {
        var type_list = relevant_events.Select(t => t.AssemblyQualifiedName).ToList();
        var batch = await event_context.Events
            .Where(e => type_list.Contains(e.Payload_type))
            .Where(e => e.Row_version_long > checkpoint)
            .OrderBy(e => e.Row_version_long)
            .Take(Batch_size)
            .ToListAsync();
        
        return batch;
    }

    private long Get_checkpoint()
    {
        using var scope = _serviceProvider.CreateScope();
        using var read_context = scope.ServiceProvider.GetRequiredService<Read_context>();

        var projection_name = typeof(TProjection).Name;
        var checkpoint = read_context.Checkpoints.Find(projection_name);

        if (checkpoint == null)
        {
            checkpoint = new Checkpoint
            {
                Name = projection_name,
                Last_timestamp = 0,
            };
            read_context.Checkpoints.Add(checkpoint);
            read_context.SaveChanges();
        }

        return checkpoint.Last_timestamp;
    }
}

public interface Projection
{
    Type[] Relevant_events { get; }
    long Project(object @event);
}