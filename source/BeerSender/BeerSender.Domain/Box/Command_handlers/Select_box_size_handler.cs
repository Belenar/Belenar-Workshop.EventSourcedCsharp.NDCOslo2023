using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Select_box_size_handler : Command_handler<Select_box_size, Box>
{
    public Select_box_size_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event) 
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<object> Handle_command(Box aggregate, Select_box_size command)
    {
        try
        {
            var size = Box_size.Create(command.Number_of_bottles);
            return new [] { new Box_created(size) };
        }
        catch (Box_size_exception ex)
        {
            return new[] { new Box_could_not_be_created(ex.Reason) };
        }
    }
}