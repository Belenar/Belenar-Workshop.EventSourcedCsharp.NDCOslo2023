using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public record Box_created(Guid BoxId, Box_size Size);

public record Box_failed_to_create(Guid BoxId, Box_size_exception.Fail_reason Reason);

public record Shipping_label_added(Guid BoxId, Shipping_label shipping_label);

public record Beer_added_to_box(Guid BoxId);

public record Add_beer_to_box_failed(Guid BoxId, Add_beer_to_box_exception.Fail_reason Reason);

public record Box_closed(Guid BoxId);

public record Box_cannot_be_closed(Guid BoxId, Close_box_exception.Fail_reason Reason);

public record Box_shipped(Guid BoxId);

public record Box_not_ready_to_be_shipped(Guid BoxId, Ship_box_exception.Fail_reason Reason);
