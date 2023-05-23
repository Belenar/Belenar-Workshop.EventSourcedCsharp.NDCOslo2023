namespace BeerSender.Domain.Box.Command_handlers;

public class Add_beer_to_box_handler : Command_handler<Add_beer_to_box, Box>
{
    public Add_beer_to_box_handler(Func<Guid, IEnumerable<MyEvent>> event_stream, Action<Guid, MyEvent> publish_event) :
        base(event_stream, publish_event)
    {
    }

    public override IEnumerable<MyEvent> Handle_command(Box aggregate, Add_beer_to_box command)
    {
        try
        {
            var beer = new Beer(command.Label, Beer_size.cl_330); 
            if (aggregate.bottles.Count >= aggregate.box_size.Number_of_bottles) //TODO: fix this - Store state
                return new[] { new Could_not_add_beer_to_box(Box_add_failed_reason.Box_is_full) };
            return new[] { new Beer_added_to_box(beer)};

        }
        catch (BoxException ex)
        {
            return new[] { new Box_failed_to_select_box(Enum.Parse<Box_select_reason>(ex.Reason)) };
        }
    }
}