using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain;
public abstract class Aggregate_root
{
    public List<Beer_base_event> Events { get; set; } = new List<Beer_base_event>();

    public void Raise_event(Beer_base_event @event)
    {
        Events.Add(@event);
    }
}
