using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public record Beer_base_event();

public record Box_created(Box_size Size) : Beer_base_event;

public record Box_failed_to_create(Box_size_exception.Fail_reason Reason) : Beer_base_event;

public record Shipping_label_added(Box_id Box_Id) : Beer_base_event;

public record Box_closed(Box_id Box_Id) : Beer_base_event;

public record Beer_added_to_box(Box_id Box_Id) : Beer_base_event;