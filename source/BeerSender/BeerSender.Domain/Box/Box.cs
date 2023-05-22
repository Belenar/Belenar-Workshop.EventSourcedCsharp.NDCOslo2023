using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain.Box;

internal class Box : Aggregate
{
    public Box_size Box_size { get; private set; }
    public bool Is_closed { get; private set; }

    public void Apply(object @event)
    {
        throw new NotImplementedException();
    }

    public void Apply(Box_created @event)
    {
        Box_size = @event.Size;
    }

    public void Apply(Add_beer_to_box @event)
    {

    }

    public void Apply(Close_box @event)
    {

    }

    public void Apply(Add_shipping_label @event)
    {

    }

    public void Apply(Ship_box @event)
    {

    }
}