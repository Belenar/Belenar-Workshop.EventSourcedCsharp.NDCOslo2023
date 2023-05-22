using BeerSender.Domain.Box;
using FluentAssertions;

namespace BeerSender.Tests;

public abstract class Command_test
{
    protected List<object> _past_events = new();
    protected List<object> _published_events = new();

    protected void Given(params object[] events)
    {
        _past_events = events.ToList();
    }

    protected void When(Command command)
    {
        var command_router = new Command_router(_=> _past_events, (_, ev) => _published_events.Add(ev));
        command_router.Handle_command(command);
    }

    protected void Then(params object[] new_events)
    {
        _published_events.Should().BeEquivalentTo(new_events);
    }
    
}