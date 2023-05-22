using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Add_beer_to_box_handler : Command_handler<Add_beer, Box>
{
    public Add_beer_to_box_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event)
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<object> Handle_command(Box aggregate, Add_beer command)
    {
        if (aggregate.Box_size == null)
        {
            yield return new Beer_could_not_be_added(Fail_reason.Box_has_no_size);
            yield break;
        }

        if (aggregate.Bottles.Count >= aggregate.Box_size.Number_of_bottles)
        {
            yield return new Beer_could_not_be_added(Fail_reason.Box_is_full);
            yield break;
        }

        var bottle = new Beer_bottle(command.Brewery, command.Name, command.Percentage);
        yield return new Beer_added(bottle);
    }
}