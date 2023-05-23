using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using BeerSender.Domain.Box;
using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.EventStore;

public class Event_context : DbContext
{
    public Event_context(DbContextOptions<Event_context> options) : base(options)
    {
        
    }
    public DbSet<Event> Events => Set<Event>();
}

public record Event
{
    private MyEvent? _event;
    public long Id { get; init; }
    public Guid AggregateId { get; init; }
    public DateTime Timestamp { get; init; }

    [MaxLength(256)]
    public string? PayloadType { get; private set; }
    public string? PayLoad { get; private set; }
    
    [Timestamp]
    public byte[] RowVersion { get; set; }
    
    [NotMapped]
    public MyEvent EventObj
    {
        get {
            if (_event != null) return _event;
            var type = Type.GetType(PayloadType!);
            _event = (MyEvent) JsonSerializer.Deserialize(PayLoad!, type!)!;
            return _event; 
        }
        set
        {
            _event = value;
            PayloadType = value.GetType().AssemblyQualifiedName;
            PayLoad = JsonSerializer.Serialize(value);
        }
    }
}