using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain.Box;

public class Box : Aggregate
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

    public void Apply(Box_could_not_be_created @event)
    {
        Created = false;
    }

    public void Apply(Shipping_label_added @event)
    {
        Shipping_label = @event.Shipping_label;
    }

    public void Apply(Shipping_label_could_not_be_created @event)
    {
    }

    public void Apply(Beer_added @event)
    {
        Bottles.Add(@event.Bottle);
    }

    public void Apply(Beer_could_not_be_added @event)
    {
    }
    
    public void Apply(Box_closed @event)
    {
        Is_closed = true;
    }
    
    public void Apply(Box_could_not_be_closed @event)
    {
        Is_closed = true;
    }

    public void Apply(Box_shipped @event)
    {
        Is_shipped = true;
    }

    public void Apply(Box_could_not_be_shipped @event)
    {
    }
}