using BeerSender.Domain.Box.Events;

namespace BeerSender.Web.EventStore;

public class EventService : IEventService
{
    private readonly EventContext _EventContext;

    public EventService(EventContext context)
    {
        _EventContext = context;
    }

    public IEnumerable<IEvent> GetEvents(Guid aggregateId)
        => _EventContext.Events
            .Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.RowVersion)
            .Select(e => e.WrappedEvent);

    public void WriteEvent(Guid aggregateId, IEvent @event)
        => _EventContext.Events.Add(new Event
        {
            AggregateId = aggregateId,
            Timestamp = DateTime.UtcNow,
            WrappedEvent = @event
        });
}