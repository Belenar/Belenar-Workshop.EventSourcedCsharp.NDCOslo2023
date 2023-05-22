using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain.Box;

internal class Box : Aggregate
{
    public Box_size? Box_size { get; private set; }
    public bool Created { get; private set; }
    public bool Is_closed { get; private set; }
    public Shipping_label? Shipping_label { get; private set; }
    public List<Beer_bottle> Bottles { get; } = new();
    public bool Is_shipped { get; private set; }

    public void Apply(object @event)
    {
        throw new NotImplementedException();
    }

    public void Apply(Box_created @event)
    {
        Box_size = @event.Size;
        Created = true;
    }

    public void Apply(Box_failed_to_create @event)
    {
        Created = false;
    }

    public void Apply(Shipping_label_added @event)
    {
        Shipping_label = @event.Shipping_label;
    }

    public void Apply(Beer_added_to_box @event)
    {
        Bottles.Add(@event.Bottle);
    }

    public void Apply(Add_beer_to_box_failed @event)
    {
    }

    public void Apply(Box_closed @event)
    {
        Is_closed = true;
    }

    public void Apply(Box_cannot_be_closed @event)
    {
        Is_closed = true;
    }

    public void Apply(Box_shipped @event)
    {
        Is_shipped = true;
    }

    public void Apply(Box_not_ready_to_be_shipped @event)
    {
    }
}