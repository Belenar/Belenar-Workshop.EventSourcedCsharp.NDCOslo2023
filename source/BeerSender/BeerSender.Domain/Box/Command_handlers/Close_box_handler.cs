namespace BeerSender.Domain.Box.Command_handlers;

public class Close_box_handler : Command_handler<Close_box, Box>
{
    public Close_box_handler(Func<Guid, IEnumerable<MyEvent>> event_stream, Action<Guid, MyEvent> publish_event) : base(
        event_stream, publish_event)
    {
    }

    public override IEnumerable<MyEvent> Handle_command(Box aggregate, Close_box command)
    {
        if (aggregate.bottles.Count > aggregate.box_size.Number_of_bottles)
            return new[] { new Could_not_close_box(Box_close_failed_reason.Box_is_too_full) };

        if (aggregate.bottles.Count < aggregate.box_size.Number_of_bottles)
            return new[] { new Could_not_close_box(Box_close_failed_reason.Box_is_not_full) };

        return new[] { new Box_closed() };
    }
}
