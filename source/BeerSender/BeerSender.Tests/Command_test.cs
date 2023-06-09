﻿using BeerSender.Domain;
using BeerSender.Domain.Box.Commands;
using FluentAssertions;

namespace BeerSender.Tests;

public abstract class Command_test
{
    private List<object> _past_events = new();
    private readonly List<object> _published_events = new();

    protected void Given(params object[] events)
    {
        _past_events = events.ToList();
    }

    protected void When(Command command)
    {
        var command_router = new Command_router(
            _ => _past_events,
            (_, ev) => _published_events.Add(ev));

        command_router.Handle_command(command);
    }

    protected void Then(params object[] expected_events)
    {
        _published_events.Should().BeEquivalentTo(expected_events);
    }
}