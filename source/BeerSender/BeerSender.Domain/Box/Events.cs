using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public record Box_created(Box_size Size);

public record Box_could_not_be_created(Fail_reason Reason);

public record Shipping_label_added(Shipping_label Shipping_label);

public record Shipping_label_could_not_be_created(Fail_reason Reason);

public record Beer_added(Beer_bottle Bottle);

public record Beer_could_not_be_added(Fail_reason Reason);

public record Box_closed;

public record Box_could_not_be_closed(Fail_reason Reason);

public record Box_shipped;

public record Box_could_not_be_shipped(Fail_reason Reason);
