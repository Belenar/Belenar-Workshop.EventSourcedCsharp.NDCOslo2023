using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain.Box;

public class Box : IAggregate
{
    public Shipping_label? Shipping_label { get; private set; }
    public Box_size? Box_size { get; private set; }
    public List<Beer_bottle> Bottles { get; } = new();
    public bool Created { get; private set; }
    public bool Is_closed { get; private set; }
    public bool Is_shipped { get; private set; }
    
    public void Apply(object @event)
    {
        throw new NotImplementedException();
    }

    public void Apply(Box_created @event)
    {
        Created = true;
        Box_size = @event.Size;
    }
    
    public void Apply(Box_failed_to_create @event)
    {
    }
    
    public void Apply(Shipping_label_added @event)
    {
        Shipping_label = @event.Label;
    }
    
    public void Apply(Beer_added_to_box @event)
    {
        Bottles.Add(@event.Bottle);
    }
    
    public void Apply(Add_beer_failed @event)
    {
    }
    
    public void Apply(Box_closed @event)
    {
        Is_closed = true;
    }
    
    public void Apply(Could_not_close_box @event)
    {
    }
    
    public void Apply(Box_shipped @event)
    {
        Is_shipped = true;
    }
    
    public void Apply(Box_was_not_ready_to_ship @event)
    {
    }
}