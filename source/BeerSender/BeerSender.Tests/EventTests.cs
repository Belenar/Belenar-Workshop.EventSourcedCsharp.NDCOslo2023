using BeerSender.Domain.Box;

namespace BeerSender.Tests;

public class EventTests
{
    private Box box;
    public EventTests()
    {
        box = new Box();
    }
    
    [Fact]
    void CanApplyEvent()
    {
        var beer = new Beer("Yes", Beer_size.cl_330);
        var added_beer_to_box = new Added_beer_to_box(beer);
        
        box.Apply(added_beer_to_box);
        
        Assert.Equal(1, box.bottles.Count);
    }
}