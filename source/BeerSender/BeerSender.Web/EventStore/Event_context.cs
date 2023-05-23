using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.EventStore
{
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
        public Guid Aggerage_id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Payload_type { get; set; }
        public string? Payload { get; set; }
        
        [Timestamp]
        public byte[]? Row_version { get; set; }
    }
}
