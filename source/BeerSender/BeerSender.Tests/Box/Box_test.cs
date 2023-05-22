using BeerSender.Domain.Box;
using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Tests.Box;

public class Box_test : Command_test
{
    private readonly Guid _aggregate_id = Guid.NewGuid();

    // Commands
    protected Select_box_size Select_box_size_with_number_of_bottles(
        int number_of_bottles)
    {
        return new Select_box_size(_aggregate_id, number_of_bottles);
    }

    protected Add_shipping_label Add_shipping_label(
        string carrier, string tracking_code)
    {
        return new Add_shipping_label(_aggregate_id, carrier, tracking_code);
    }

    protected Add_beer Add_beer_to_box(string brewery, string name, decimal percentage)
    {
        return new Add_beer(_aggregate_id, brewery, name, percentage);
    }

    protected Close_box Close_box()
    {
        return new Close_box(_aggregate_id);
    }

    protected Ship_box Ship_box()
    {
        return new Ship_box(_aggregate_id);
    }

    // Events
    protected Box_created Box_is_created(int number_of_bottles)
    {
        return new Box_created(Box_size.Create(number_of_bottles));
    }

    protected Box_could_not_be_created Box_could_not_be_created()
    {
        return new Box_could_not_be_created(Fail_reason.Invalid_box_size);
    }

    protected Shipping_label_added Shipping_label_added_with_carrier_and_code(
        string carrier, string label)
    {
        return new Shipping_label_added(
            Shipping_label.Create(carrier, label));
    }

    protected Shipping_label_could_not_be_created Shipping_label_could_not_be_created_with_invalid_carrier()
    {
        return new Shipping_label_could_not_be_created(Fail_reason.Invalid_carrier);
    }

    protected Shipping_label_could_not_be_created Shipping_label_could_not_be_created_with_invalid_code()
    {
        return new Shipping_label_could_not_be_created(Fail_reason.Invalid_tracking_code);
    }

    protected Beer_added Beer_added_to_box(string brewery, string name, decimal percentage)
    {
        return new Beer_added(new Beer_bottle(brewery, name, percentage));
    }

    protected Beer_could_not_be_added Beer_could_not_be_added_because_box_was_full()
    {
        return new Beer_could_not_be_added(Fail_reason.Box_is_full);
    }

    protected Beer_could_not_be_added Beer_could_not_be_added_because_box_has_no_size()
    {
        return new Beer_could_not_be_added(Fail_reason.Box_has_no_size);
    }

    protected Box_closed Box_was_closed()
    {
        return new Box_closed();
    }

    protected Box_could_not_be_closed Box_could_not_be_closed_because_it_was_empty()
    {
        return new Box_could_not_be_closed(Fail_reason.Box_is_empty);
    }

    protected Box_shipped Box_was_shipped()
    {
        return new Box_shipped();
    }

    protected Box_could_not_be_shipped Box_could_not_be_shipped_because_it_has_no_label()
    {
        return new Box_could_not_be_shipped(Fail_reason.Box_has_no_label);
    }

    protected Box_could_not_be_shipped Box_could_not_be_shipped_because_it_was_not_closed()
    {
        return new Box_could_not_be_shipped(Fail_reason.Box_is_not_closed);
    }
}