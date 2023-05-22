using BeerSender.Domain.Box.Command_handlers;
using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<IEvent>> _event_stream;
    private readonly Action<Guid, IEvent> _publish_event;

    public Command_router(
        Func<Guid, IEnumerable<IEvent>> event_stream,
        Action<Guid, IEvent> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle_command(ICommand command)
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