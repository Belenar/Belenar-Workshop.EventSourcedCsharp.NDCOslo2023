using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using BeerSender.Web.JsonHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BeerSender.Web.EventStore;

public class Event_context : DbContext
{
    public Event_context(DbContextOptions<Event_context> options) : base(options)
    {
    }

    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .Property(p => p.Row_version_long)
            .HasComputedColumnSql("CONVERT (BIGINT, Row_version)", stored: true);
        base.OnModelCreating(modelBuilder);
    }
}

public class Event
{
    public long Id { get; set; }
    public Guid Aggregate_id { get; set; }
    public DateTime Timestamp { get; set; }
    [MaxLength(256)]
    public string? Payload_type { get; set; }
    public string? Payload { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public long Row_version_long { get; set; }
    [Timestamp]
    public byte[] Row_version { get; set; }

    private object? _event;

    [NotMapped]
    public object Object
    {
        get
        {
            if (_event == null)
            {
                var type = Type.GetType(Payload_type!);
                _event = JsonSerializer.Deserialize(Payload!, type!, new JsonSerializerOptions
                {
                    TypeInfoResolver = new PrivateConstructorContractResolver()
                });
            }

            return _event;
        }
        set
        {
            _event = value;
            Payload_type = value.GetType().AssemblyQualifiedName;
            Payload = JsonSerializer.Serialize(value);
        }
    }
}
