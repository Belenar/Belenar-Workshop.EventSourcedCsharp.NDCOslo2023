using System.Reflection;

namespace BeerSender.Domain.Box;

public interface Command
{
    Guid AggregateId { get; }
}

public static class CommandHelper
{
    public static Dictionary<string, Type> GetAllCommands()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().Where(t => t.IsDefined(typeof(MyCommandAttribute)));
        Dictionary<string, Type> myAttributes = new Dictionary<string, Type>();
        foreach (var t in types)
        {
            var attr = (MyCommandAttribute[])Attribute.GetCustomAttributes(t, typeof(MyCommandAttribute));
            if (attr.Length > 1)
                throw new Exception("Should only have one CommandAttribute pr class");
            myAttributes[attr[0].Event_name] = t;
        }
        return myAttributes;
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