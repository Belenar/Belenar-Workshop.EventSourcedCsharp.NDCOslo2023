using BeerSender.Domain.Box;
using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Tests.Box;

public class Box_test : Command_test
{
    private readonly Guid _aggregate_id = Guid.NewGuid();

    #region Commands
    protected Select_box_size Select_box_size_with_number_of_bottles(
        int number_of_bottles)
    {
        return new Select_box_size(_aggregate_id, number_of_bottles);
    }
    
    protected Add_shipping_label Add_shipping_label_with_carrier_and_tracking_code(
        string carrier,
        string tracking_code)
    {
        return new Add_shipping_label(_aggregate_id, carrier, tracking_code);
    }
    #endregion

    #region Events
    protected Box_created Box_is_created(int number_of_bottles)
    {
        return new Box_created(Box_size.Create(number_of_bottles));
    }
    
    protected Shipping_label_added Shipping_label_is_added(string carrier, string tracking_code)
    {
        return new Shipping_label_added(Shipping_label.Create(carrier, tracking_code));
    }
    
    protected Add_shipping_label_failed Add_shipping_label_has_failed(Fail_reason reason)
    {
        return new Add_shipping_label_failed(reason);
    }
    #endregion
}