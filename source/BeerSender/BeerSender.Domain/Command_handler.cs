﻿using BeerSender.Domain.Box.Commands;

namespace BeerSender.Domain;

public abstract class Command_handler<TCommand, TAggregate>
    where TCommand : Command
    where TAggregate : Aggregate, new()
{
    private readonly Func<Guid, IEnumerable<object>> _event_stream;
    private readonly Action<Guid, object> _publish_event;

    protected Command_handler(
        Func<Guid, IEnumerable<object>> event_stream,
        Action<Guid, object> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle(TCommand command)
    {
        var aggregate = new TAggregate();

        var events = _event_stream(command.AggregateId);

        foreach (var @event in events)
        {
            aggregate.Apply((dynamic) @event);
        }

        var new_events = Handle_command(aggregate, command);

        foreach (var new_event in new_events)
        {
            _publish_event(command.AggregateId, new_event);
        }

    }

    protected abstract IEnumerable<object> Handle_command(TAggregate aggregate, TCommand command);
}