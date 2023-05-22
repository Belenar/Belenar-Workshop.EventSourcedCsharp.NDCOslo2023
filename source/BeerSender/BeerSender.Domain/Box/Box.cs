using BeerSender.Domain.Box.Events;

namespace BeerSender.Domain.Box;
public class Box : Aggregate_root
{
    public Box_id Id { get; private set; } = default!;

    public Box_size Size { get; private set; } = default!;

    public int Beers_inside { get; private set; }

    public bool Is_closed { get; private set; }

    public Shipping_label? Shipping_label { get; private set; }

    private Box()
    {
    }

    public static Box Create(Box_size box_Size)
    {
        Box box = new()
        {
            Id = new Box_id(Guid.NewGuid()),
            Size = box_Size
        };

        return box;
    }

    public void Add_beer()
    {
        Beers_inside++;
        Raise_event(new Beer_added_to_box(Id));
    }

    public void Close()
    {
        Is_closed = true;
        Raise_event(new Box_closed(Id));
    }

    public void Add_shipping_label(Shipping_label shipping_label)
    {
        Shipping_label = shipping_label;
        Raise_event(new Shipping_label_added(Id));
    }
}
