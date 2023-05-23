using BeerSender.Domain.Box.Events;

namespace BeerSender.Web.EventStore;

public interface IEventService
{
    IEnumerable<IEvent> GetEvents(Guid aggregateId);
    void WriteEvent(Guid aggregateId, IEvent @event);
}