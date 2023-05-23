using BeerSender.Domain.Box;
using FluentAssertions;

namespace BeerSender.Tests;

public abstract class Command_test
{
    private readonly List<Event> _published_events = new();
    private List<Event> _past_events = new();

    protected void Given(params Event[] events)
    {
        _past_events = events.ToList();
    }

    protected void When(params Command[] commands)
    {
        var command_router = new Command_router(_ => _past_events, (_, ev) => _published_events.Add(ev));
        foreach (var command in commands)
        {
            command_router.Handle_command(command);
        }
    }

    protected void Then(params Event[] new_events)
    {
        Assert.Equivalent(_published_events, new_events);
    }
}