namespace BeerSender.Domain.Box;

public interface Command
{ 
    Guid AggregateId { get; }
}

public record Select_box_size(Guid AggregateId, int Number_of_bottles) : Command;

public record Close_box(Guid AggregateId): Command;

public record Ship_box(Guid AggregateId): Command;

public record Add_shipping_label_to_box(Guid AggregateId, string Carrier, string Tracking_code): Command;

public record Add_beer_to_box(Guid AggregateId, string Label, string Quantity): Command;