using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BeerSender.Web.EventStore;

public class Event_context : DbContext
{
    public Event_context(DbContextOptions<Event_context> options) : base(options)
    {
    }

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
    public byte[] RowVersion { get; set; }
}
