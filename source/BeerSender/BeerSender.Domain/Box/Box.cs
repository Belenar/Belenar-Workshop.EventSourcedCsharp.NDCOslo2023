namespace BeerSender.Domain.Box;

public class Box : Aggregate
{
    public Box_size box_size { get; private set; }
    public bool Box_is_closed { get; private set; }
    public Label? Box_label { get; private set; }
    public Shipment_identifier? Shipment_identifier { get; private set; }
    public IList<Beer> bottles { get; } = new List<Beer>();
    public bool IsShipped { get; private set; }


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

    public void Apply(Label_added_to_box @event)
    {
        Box_label = @event._Label;
    }


    public void Apply(Box_shipped @event)
    {
        Shipment_identifier = @event.Shipment_identifier;
        IsShipped = true;
    }

    public void Apply(Beer_added_to_box @event)
    {
        bottles.Add(@event.beer);
    }

    public void Apply(BoxException @event)
    {
        Console.WriteLine("Got error event of type: " + @event);
    }
}