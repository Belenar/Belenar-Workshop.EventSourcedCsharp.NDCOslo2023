using BeerSender.Domain;
using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using FluentAssertions;

namespace BeerSender.Tests;

public abstract class Command_test
{
    private List<IEvent> _past_events = new();
    private readonly List<IEvent> _published_events = new();

    protected void Given(params IEvent[] events)
    {
        _past_events = events.ToList();
    }

    protected void When(ICommand command)
    {
        var command_router = new Command_router(
            _ => _past_events,
            (_, ev) => _published_events.Add(ev));

        command_router.Handle_command(command);
    }

    protected void Then(params object[] new_events)
    {
        _published_events.Should().BeEquivalentTo(new_events);
    }
}