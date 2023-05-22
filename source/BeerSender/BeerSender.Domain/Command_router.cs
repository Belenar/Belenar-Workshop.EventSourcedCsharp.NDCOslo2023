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
                var handler = new Select_box_size_handler(_event_stream, _publish_event);
                handler.Handle(select_box_size);
                break;
        }
    }
}

