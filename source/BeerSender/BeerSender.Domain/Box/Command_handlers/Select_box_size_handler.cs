using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Select_box_size_handler : Command_handler<Select_box_size, Box>
{
    public Select_box_size_handler(Func<Guid, IEnumerable<IEvent>> event_stream, Action<Guid, IEvent> publish_event) 
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<IEvent> Handle_command(Box aggregate, Select_box_size command)
    {
        Box_size? size = null;
        Box_failed_to_create? box_failed_to_create = null;
        
        try
        {
            size = Box_size.Create(command.Number_of_bottles); 
        }
        catch (Box_exception ex)
        {
            box_failed_to_create = new Box_failed_to_create(ex.Reason);
        }

        if (size is not null)
        {
            yield return new Box_created(size);
        } else if (box_failed_to_create is not null)
        {
            yield return box_failed_to_create;
        }
    }
}