using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.EventStore;

public class EventContext : DbContext
{
    public DbSet<Event> Events => Set<Event>();
    
    public EventContext(DbContextOptions<EventContext> options) 
        : base(options)
    {
    }
}