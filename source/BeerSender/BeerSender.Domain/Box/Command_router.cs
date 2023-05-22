using BeerSender.Domain.Box.Command_handlers;

namespace BeerSender.Domain.Box;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<Event>> _event_stream;
    private readonly Action<Guid, Event> _publish_event;

    public Command_router(
        Func<Guid, IEnumerable<Event>> event_stream,
        Action<Guid, Event> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle_command(Command command)
    {
        switch (command)
        {
            case Select_box_size select_box_size:
            {
                var handler = new Select_box_size_handler(_event_stream, _publish_event);
                handler.Handle(select_box_size);
                return;
            }
            case Close_box close_box:
            {
                var handler = new Close_box_handler(_event_stream, _publish_event);
                handler.Handle(close_box);
                return;
            }
            case Add_beer_to_box add_beer:
            {
                var handler = new Add_beer_to_box_handler(_event_stream, _publish_event);
                handler.Handle(add_beer);
                return;
            }
            case Add_label_to_box add_label:
            {
                var handler = new Add_label_to_box_handler(_event_stream, _publish_event);
                handler.Handle(add_label);
                return;
            }
        }
    }
}