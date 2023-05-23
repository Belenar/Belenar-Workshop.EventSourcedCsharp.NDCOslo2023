using BeerSender.Domain.Box;

namespace BeerSender.Web.EventStore;

public interface Event_service
{
    IEnumerable<MyEvent> GetEvents(Guid aggregate_id);
    void WriteEvent(Guid aggregate_id, MyEvent @event);
}

public class Event_service_implementation : Event_service
{
    private readonly Event_context _db_context;

    public Event_service_implementation(Event_context db_context)
    {
        _db_context = db_context;
    }
    public IEnumerable<MyEvent> GetEvents(Guid aggregate_id)
    {
        return _db_context.Events
            .Where(e => e.AggregateId == aggregate_id)
            .OrderBy(e => e.RowVersion)
            .Select(e => e.EventObj)
            .ToList();
    }

    public void WriteEvent(Guid aggregate_id, MyEvent @event)
    {
        var new_event = new Event
        {
            AggregateId = aggregate_id,
            EventObj = @event,
            Timestamp = DateTime.UtcNow
        };

        _db_context.Events.Add(new_event);
        _db_context.SaveChanges();
    }
}