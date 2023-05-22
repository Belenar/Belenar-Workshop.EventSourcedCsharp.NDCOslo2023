using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public record Box_created(Box_size Size, Box_id Box_Id);
public record Box_failed_to_create(Box_size_exception.Fail_reason Reason);
public record Shipping_label_added(Shipping_label Shipping_label, Box_id Box_Id);
public record Beer_added_to_box(Beer_bottle Beer_bottle, Box_id Box_Id);
public record Beer_added_to_box_failed(Add_beer_bottle_exception.Fail_reason Reason, Box_id Box_Id, Beer_bottle Beer_bottle);
public record Box_closed();
public record Box_close_failed(Box_close_failed_exception.Fail_reason Reason);
public record Ship_box(DateTimeOffset When);