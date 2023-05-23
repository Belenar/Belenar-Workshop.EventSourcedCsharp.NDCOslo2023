namespace BeerSender.Domain.Box;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class MyCommandAttribute : Attribute
{
    public  string Event_name { get; }

    public MyCommandAttribute(string event_name)
    {
        Event_name = event_name;
    }
}