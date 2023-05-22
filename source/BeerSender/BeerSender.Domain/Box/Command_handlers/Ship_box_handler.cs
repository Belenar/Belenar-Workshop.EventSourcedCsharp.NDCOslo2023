using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Ship_box_handler : Command_handler<Ship_box, Box>
{
    public Ship_box_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event)
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<object> Handle_command(Box aggregate, Ship_box command)
    {
        if (!aggregate.Is_closed)
        {
            yield return new Box_could_not_be_shipped(Fail_reason.Box_is_not_closed);
            yield break;
        }
        if (aggregate.Shipping_label == null)
        {
            yield return new Box_could_not_be_shipped(Fail_reason.Box_has_no_label);
            yield break;
        }

        yield return new Box_shipped();
    }
}