namespace BeerSender.Domain.Box;

public class Box : Aggregate
{
    public Box_size box_size { get; private set; }
    public bool Box_is_closed { get; private set; }
    public Shipping_label Box_label { get; private set; }
    public Shipment_identifier Shipment_identifier { get; private set; }
    
    public void Apply(object @event)
    {
        throw new NotImplementedException();
    }
    
    public void Apply(Box_selected @event)
    {
        box_size = @event.Box_size;
    }
    
    public void Apply(Box_closed @event)
    {
        Box_is_closed = true;
    }
    
    public void Apply(Box_label_added @event)
    {
        Box_label = @event.Shipping_label;
    }


    public void Apply(Box_shipped @event)
    {
        Shipment_identifier = @event.Shipment_identifier;
    }

    public int Number_of_beers { get; private set; }

    public void Apply(Added_beer_to_box @event)
    { 
        Number_of_beers++;
    }
    
    public void Apply(BoxException @event)
    {
        Console.WriteLine("Got error event of type: " + @event);
    }
}