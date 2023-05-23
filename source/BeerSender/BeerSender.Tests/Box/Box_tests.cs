using System.Collections;
using BeerSender.Domain.Box;

namespace BeerSender.Tests;

public class Box_tests : Command_test
{
    protected readonly Guid aggregateId = new();

    protected Select_box_size select_box_size(int numberOfBottles)
    {
        return new Select_box_size(aggregateId, numberOfBottles);
    }

    protected static Box_selected Box_selected(int numberOfBottles)
    {
        return new Box_selected(new Box_size(numberOfBottles));
    }

    protected MyEvent[] too_many_beers_added_to_a_box()
    {
        var events = new List<MyEvent> { Box_selected(numberInBox) };
        events.AddRange(add_beers_to_box_events(numberInBox+1));
        return events.ToArray();
    }
    
    protected MyEvent[] right_amout_of_beers_added_to_a_box()
    {
        var events = new List<MyEvent> { Box_selected(numberInBox) };
        events.AddRange(add_beers_to_box_events(numberInBox));
        return events.ToArray();
    }
    
    protected MyEvent[] too_few_beers_added_to_a_box()
    {
        var events = new List<MyEvent> { Box_selected(numberInBox) };
        events.AddRange(add_beers_to_box_events(numberInBox-1));
        return events.ToArray();
    }
    
    protected Command close_box()
    {
        return new Close_box(aggregateId);
    }

    protected Command[] add_beers_to_box(int number_of_events_to_create)
    {
        return Enumerable.Repeat((Command)new Add_beer_to_box(aggregateId, "Super", "cl_330"),number_of_events_to_create).ToArray();
    }
    
    protected MyEvent[] add_beers_to_box_events(int number_of_events_to_create)
    {
        return Enumerable.Repeat((MyEvent)new Beer_added_to_box(new Beer("Super", Beer_size.cl_330)), number_of_events_to_create).ToArray();    
    }
    
    private const int numberInBox = 6;
}