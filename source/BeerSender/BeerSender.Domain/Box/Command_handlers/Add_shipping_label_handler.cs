using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Add_shipping_label_handler : Command_handler<Add_shipping_label, Box>
{
    public Add_shipping_label_handler(Func<Guid, IEnumerable<IEvent>> event_stream, Action<Guid, IEvent> publish_event)
        : base(event_stream, publish_event)
    {
    }

    protected override IEnumerable<IEvent> Handle_command(Box aggregate, Add_shipping_label command)
    {
        Shipping_label? shipping_label = null;
        Add_shipping_label_failed? add_shipping_label_failed = null;
        
        try
        {
            shipping_label = Shipping_label.Create(command.Carrier, command.Tracking_code);
        }
        catch (Shipping_label_exception ex)
        {
            add_shipping_label_failed = new Add_shipping_label_failed(ex.Reason);
        }

        if (shipping_label is not null)
        {
            yield return new Shipping_label_added(shipping_label);
        } else if (add_shipping_label_failed is not null)
        {
            yield return add_shipping_label_failed;
        }
    }
}