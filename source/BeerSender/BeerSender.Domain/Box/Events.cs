using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public readonly record struct Box_created(Box_size Size);
public readonly record struct Box_failed_to_create(Fail_reason Reason);

public readonly record struct Shipping_label_added(Shipping_label Label);

public readonly record struct Beer_added_to_box(Beer_bottle Bottle);
public readonly record struct Add_beer_failed(Fail_reason Reason);

public readonly record struct Box_closed;
public readonly record struct Could_not_close_box(Fail_reason Reason);

public readonly record struct Box_shipped;
public readonly record struct Box_was_not_ready_to_ship(Fail_reason Reason);