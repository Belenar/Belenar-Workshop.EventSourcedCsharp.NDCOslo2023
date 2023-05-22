using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain;

public abstract class Command_handler<TCommand, TAggregate>
    where TCommand : ICommand
    where TAggregate : IAggregate, new()
{
    private readonly Func<Guid, IEnumerable<IEvent>> _event_stream;
    private readonly Action<Guid, IEvent> _publish_event;

    protected Command_handler(
        Func<Guid, IEnumerable<IEvent>> event_stream,
        Action<Guid, IEvent> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle(TCommand command)
    {
        var aggregate = new TAggregate();

        var events = _event_stream(command.Aggregate_id);

        foreach (var @event in events)
        {
            aggregate.Apply((dynamic) @event);
        }

        var new_events = Handle_command(aggregate, command);

        foreach (var new_event in new_events)
        {
            _publish_event(command.Aggregate_id, new_event);
        }

    }

    protected abstract IEnumerable<IEvent> Handle_command(TAggregate aggregate, TCommand command);
}