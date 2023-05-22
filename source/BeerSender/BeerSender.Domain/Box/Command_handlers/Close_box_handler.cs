using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Command_handlers;

public class Close_box_handler : Command_handler<Close_box, Box>
{
    public Close_box_handler(Func<Guid, IEnumerable<object>> event_stream, Action<Guid, object> publish_event)
        : base(event_stream, publish_event)
    { }

    protected override IEnumerable<object> Handle_command(Box aggregate, Close_box command)
    {
        if (!aggregate.Bottles.Any())
        {
            yield return new Box_could_not_be_closed(Fail_reason.Box_is_empty);
            yield break;
        }

        yield return new Box_closed();
    }
}