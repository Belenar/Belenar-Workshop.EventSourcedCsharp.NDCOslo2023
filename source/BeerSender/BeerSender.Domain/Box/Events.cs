using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public readonly record struct Box_created(Guid Box_id, Box_size Size);
public readonly record struct Box_failed_to_create(Box_exception.Fail_reason Reason);

public readonly record struct Shipping_label_added(Guid Box_id, Shipping_label Label);

public readonly record struct Beer_added_to_box(Guid Box_id, Beer Beer);
public readonly record struct Add_beer_failed(Beer_exception.Fail_reason Reason);

public readonly record struct Box_closed(Guid Box_id);
public readonly record struct Could_not_close_box(Guid Box_id, Box_exception.Fail_reason Reason);

public readonly record struct Box_shipped(Guid Box_id);
public readonly record struct Box_was_not_ready_to_ship(Guid Box_id, Box_exception.Fail_reason Reason);