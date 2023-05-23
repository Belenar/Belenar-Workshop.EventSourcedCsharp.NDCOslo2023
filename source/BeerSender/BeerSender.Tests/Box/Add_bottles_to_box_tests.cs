using BeerSender.Domain.Box;

namespace BeerSender.Tests;

public class Add_bottle_to_box_test : Box_tests
{
    [Theory]
    [InlineData(1,1)]
    [InlineData(2,2)]
    [InlineData(3,3)]
    [InlineData(4,4)]
    [InlineData(5,5)]
    [InlineData(6,6)]
    public void Add_beer_to_box_should_have_correct_count(int numberOfBottles, int expectedCountInBox)
    {
        Given(Box_selected(6));
        When(add_beers_to_box(numberOfBottles));
        Then(Enumerable
            .Repeat((Event)new Beer_added_to_box(new Beer("Super", Beer_size.cl_330)), expectedCountInBox).ToArray());
    }
    
    [Fact]
    public void Add_beer_to_box_should_have_correct_count_when_error()
    {
        Given(right_amout_of_beers_added_to_a_box());
        When(add_beers_to_box(1));
        Then(new Could_not_add_beer_to_box(Box_add_failed_reason.Box_is_full));
    }
    

}