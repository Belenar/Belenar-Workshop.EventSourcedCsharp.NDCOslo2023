using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public record Box_created(Box_size Size);

public record Box_failed_to_create(Box_size_exception.Fail_reason Reason);

public record Shipping_label_added(Shipping_label Shipping_label);

public record Beer_added_to_box(Beer_bottle Bottle);

public record Add_beer_to_box_failed(Add_beer_to_box_exception.Fail_reason Reason);

public record Box_closed;

public record Box_cannot_be_closed(Close_box_exception.Fail_reason Reason);

public record Box_shipped;

public record Box_not_ready_to_be_shipped(Ship_box_exception.Fail_reason Reason);
