using Microsoft.AspNetCore.SignalR;

namespace BeerSender.Web.Hubs;

public class EventHub : Hub
{
    public async Task publish_event(Guid aggregate_id, object @event)
    {
        await Clients.Group(aggregate_id.ToString())
            .SendAsync("publish_event", aggregate_id, @event);
    }

    public async Task subscribe_to_aggregate(Guid aggregate_id)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, aggregate_id.ToString());
    }
}