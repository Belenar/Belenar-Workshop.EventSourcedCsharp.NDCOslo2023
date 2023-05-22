using BeerSender.Domain.Box.Command_handlers;
using BeerSender.Domain.Box.Commands;

namespace BeerSender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<object>> _event_stream;
    private readonly Action<Guid, object> _publish_event;

    public Command_router(
        Func<Guid, IEnumerable<object>> event_stream,
        Action<Guid, object> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle_command(Command command)
    {
        switch (command)
        {
            case Select_box_size select_box_size:
                new Select_box_size_handler(_event_stream, _publish_event)
                    .Handle(select_box_size);
                break;
            case Add_shipping_label add_shipping_label:
                new Add_shipping_label_handler(_event_stream, _publish_event)
                    .Handle(add_shipping_label);
                break;
            case Add_beer add_beer_to_box:
                new Add_beer_to_box_handler(_event_stream, _publish_event)
                    .Handle(add_beer_to_box);
                break;
            case Close_box close_box:
                new Close_box_handler(_event_stream, _publish_event)
                    .Handle(close_box);
                break;
            case Ship_box ship_box:
                new Ship_box_handler(_event_stream, _publish_event)
                    .Handle(ship_box);
                break;
        }
    }
}

