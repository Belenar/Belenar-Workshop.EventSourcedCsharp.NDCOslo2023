namespace BeerSender.Domain.Box;

public abstract class Command_handler<TCommand, TAggregate>
    where TCommand : Command
    where TAggregate : Aggregate, new()
{
    private readonly Func<Guid, IEnumerable<Event>> _event_stream;
    private readonly Action<Guid, Event> _publish_event;

    public Command_handler(
        Func<Guid, IEnumerable<Event>> event_stream,
        Action<Guid, Event> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle(TCommand command)
    {
        var aggregate = new TAggregate();
        var events = _event_stream(command.AggregateId);
        foreach (var @event in events) aggregate.Apply((dynamic)@event); // To select the correct overload

        var new_events = Handle_command(aggregate, command);
        foreach (var new_event in new_events) _publish_event(command.AggregateId, new_event);
    }

    public abstract IEnumerable<Event> Handle_command(TAggregate aggregate, TCommand command);
}