using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.EventStore;

public class Event_context : DbContext
{
    public Event_context(DbContextOptions<Event_context> options) : base(options)
    { }

    public DbSet<Event> Events => Set<Event>();
}

public class Event
{
    public long Id { get; set; }
    public Guid Aggregate_id { get; set; }
    public DateTime Timestamp { get; set; }
    [MaxLength(256)]
    public string? Payload_type { get; set; }
    public string? Payload { get; set; }
    [Timestamp]
    public byte[]? Row_version { get; set; }

    private object? _event;

    [NotMapped] 
    public object Object { 
        get {
            if (_event == null)
            {
                var type = Type.GetType(Payload_type!);
                _event = JsonSerializer.Deserialize(Payload!, type!);
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