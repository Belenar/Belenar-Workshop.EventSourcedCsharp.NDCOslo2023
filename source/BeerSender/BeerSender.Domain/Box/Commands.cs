using System.Runtime.InteropServices;

namespace BeerSender.Domain.Box;

public interface Command
{
    Guid AggregateId { get; }
}

class MyCommandAttribute : Attribute
{
    public MyCommandAttribute(string event_name)
    {
        
    }
}

[MyCommand(nameof(Select_box_size))]
public record Select_box_size(Guid AggregateId, int Number_of_bottles) : Command;


[MyCommand(nameof(Close_box))]
public record Close_box(Guid AggregateId) : Command;


[MyCommand(nameof(Ship_box))]
public record Ship_box(Guid AggregateId) : Command;


[MyCommand(nameof(Add_label_to_box))]
public record Add_label_to_box(Guid AggregateId, string Carrier, string Tracking_code) : Command;


[MyCommand(nameof(Add_beer_to_box))]
public record Add_beer_to_box(Guid AggregateId, string Label, string Quantity) : Command;