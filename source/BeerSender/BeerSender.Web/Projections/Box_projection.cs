using BeerSender.Domain.Box.Events;
using BeerSender.Web.EventStore;
using BeerSender.Web.ReadStore;

namespace BeerSender.Web.Projections;

public class Box_projection : Projection
{
    private readonly Read_context _db_context;

    public Box_projection(Read_context db_context)
    {
        _db_context = db_context;
    }

    public Type[] Relevant_events => new[]
    {
        typeof(Box_created),
        typeof(Shipping_label_added),
        typeof(Beer_added)
    };

    public long Project(Event @event)
    {
        switch (@event.Object)
        {
            case Box_created box_created:
                Create_box(@event.Aggregate_id, box_created);
                break;
            case Shipping_label_added label_added:
                Add_label(@event.Aggregate_id, label_added);
                break;
            case Beer_added beer_added:
                Add_beer(@event.Aggregate_id, beer_added);
                break;
        }
        _db_context.SaveChanges();
        return @event.Row_version_long;
    }

    private void Create_box(Guid aggregate_id, Box_created box_created)
    {
        var new_box = new Box_status
        {
            Aggregate_id = aggregate_id,
            Size = box_created.Size.Number_of_bottles,
        };
        _db_context.Boxes.Add(new_box);
    }

    private void Add_label(Guid aggregate_id, Shipping_label_added label_added)
    {
        var box = _db_context.Boxes.Find(aggregate_id);

        if (box != null)
        {
            box.Carrier = label_added.Shipping_label.Carrier.ToString();
            box.Tracking_code = label_added.Shipping_label.Tracking_code;
        }
    }

    private void Add_beer(Guid aggregate_id, Beer_added beer_added)
    {
        var bottle = new Box_bottle
        {
            Box_id = aggregate_id,
            Brewery = beer_added.Bottle.Brewery,
            Name = beer_added.Bottle.Name,
            Percentage = beer_added.Bottle.Percentage
        };

        _db_context.Bottles.Add(bottle);
    }
}