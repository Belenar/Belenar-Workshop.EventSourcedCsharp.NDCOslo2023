namespace BeerSender.Domain.Box.Commands;

public interface ICommand
{
    Guid Aggregate_id { get; }
}

public readonly record struct Select_box_size(Guid Aggregate_id, int Number_of_bottles) : ICommand;

public readonly record struct Add_shipping_label(Guid Aggregate_id, string Carrier, string Tracking_code) : ICommand;

public readonly record struct Add_beer_to_box(Guid Aggregate_id, string Name) : ICommand;

public readonly record struct Close_box(Guid Aggregate_id) : ICommand;

public readonly record struct Ship_box(Guid Aggregate_id) : ICommand;