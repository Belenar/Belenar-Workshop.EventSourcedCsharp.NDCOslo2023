using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Add_shipping_label_handler : Command_handler<Add_shipping_label, Box>
{
    public Add_shipping_label_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event)
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<object> Handle_command(Box aggregate, Add_shipping_label command)
    {
        try
        {
            var label = Shipping_label.Create(command.Carrier, command.Tracking_code);
            return new[] { new Shipping_label_added(label) };
        }
        catch (Shipping_label_exception ex)
        {
            return new[] { new Shipping_label_could_not_be_created(ex.Reason) };
        }
    }
}