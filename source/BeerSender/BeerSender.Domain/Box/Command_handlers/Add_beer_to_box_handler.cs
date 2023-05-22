using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Add_beer_to_box_handler : Command_handler<Add_beer_to_box, Box>
{
    public Add_beer_to_box_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event)
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<object> Handle_command(Box aggregate, Add_beer_to_box command)
    {
        if (aggregate.Bottles.Count == aggregate.Box_size.Number_of_bottles)
        {
            return new[] { new Add_beer_to_box_failed(Add_beer_to_box_exception.Fail_reason.Too_many_beers) };
        }
        try
        {
            var bottle = new Beer_bottle(command.Brewery, command.Name, command.Percentage);
            return new []{new Beer_added_to_box(bottle)};
        }
        catch (Add_beer_to_box_exception ex)
        {
            return new []{new Add_beer_to_box_failed(ex.Reason)};
        }
    }
}