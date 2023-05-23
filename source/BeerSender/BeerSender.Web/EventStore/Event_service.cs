namespace BeerSender.Web.EventStore;

public interface Event_service
{
    IEnumerable<object> GetEvents(Guid aggregate_id);
    void WriteEvent(Guid aggregate_id, object @event);
}

public class Event_service_implementation : Event_service
{
    private readonly Event_context _db_context;

    public Event_service_implementation(Event_context db_context)
    {
        _db_context = db_context;
    }

    public IEnumerable<object> GetEvents(Guid aggregate_id)
    {
        var events = _db_context.Events
            .Where(e => e.Aggregate_id == aggregate_id)
            .OrderBy(e => e.Row_version)
            .Select(e => e.Object)
            .ToList();

        return events;
    }

    public void WriteEvent(Guid aggregate_id, object @event)
    {
        var new_event = new Event
        {
            Aggregate_id = aggregate_id,
            Object = @event,
            Timestamp = DateTime.UtcNow
        };

        _db_context.Events.Add(new_event);
        _db_context.SaveChanges();
    }
}