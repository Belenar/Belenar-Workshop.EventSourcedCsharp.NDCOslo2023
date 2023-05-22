using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public interface IEvent
{
}

public readonly record struct Box_created(Box_size Size) : IEvent;
public readonly record struct Box_failed_to_create(Fail_reason Reason) : IEvent;

public readonly record struct Shipping_label_added(Shipping_label Label) : IEvent;
public readonly record struct Add_shipping_label_failed(Fail_reason Reason) : IEvent;

public readonly record struct Beer_added_to_box(Beer_bottle Bottle) : IEvent;
public readonly record struct Add_beer_failed(Fail_reason Reason) : IEvent;

public readonly record struct Box_closed : IEvent;
public readonly record struct Could_not_close_box(Fail_reason Reason) : IEvent;

public readonly record struct Box_shipped : IEvent;
public readonly record struct Box_was_not_ready_to_ship(Fail_reason Reason) : IEvent;