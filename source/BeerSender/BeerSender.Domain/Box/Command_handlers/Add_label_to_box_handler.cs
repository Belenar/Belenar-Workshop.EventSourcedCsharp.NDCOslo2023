namespace BeerSender.Domain.Box.Command_handlers;

public class Add_label_to_box_handler : Command_handler<Add_label_to_box, Box>
{
    public Add_label_to_box_handler(Func<Guid, IEnumerable<MyEvent>> event_stream, Action<Guid, MyEvent> publish_event) :
        base(event_stream, publish_event)
    {
    }

    public override IEnumerable<MyEvent> Handle_command(Box aggregate, Add_label_to_box command)
    {
        try
        {
            var label = new Label(command.Carrier, command.Carrier);
            return new[] { new Label_added_to_box(label) };
        }
        catch (BoxException ex)
        {
            return new[] { new Box_failed_to_select_box(Enum.Parse<Box_select_reason>(ex.Reason)) };
        }
    }
}