using BeerSender.Domain.Box;

namespace BeerSender.Tests;

public class Close_box_tests : Box_tests
{
    [Fact]
    public void Should_not_be_able_to_close_box_when_not_full()
    {
        Given(too_few_beers_added_to_a_box());
        When(close_box());
        Then(new Could_not_close_box(Box_close_failed_reason.Box_is_not_full));
    }
    
    [Fact]
    public void Should_not_be_able_to_close_box_when_too_full()
    {
        Given(too_many_beers_added_to_a_box());
        When(close_box());
        Then(new Could_not_close_box(Box_close_failed_reason.Box_is_too_full));
    }
    
    [Fact]
    public void Should_be_able_to_close_box_when_the_right_amount_is_added()
    {
        Given(right_amout_of_beers_added_to_a_box());
        When(close_box());
        Then(new Box_closed());
    }

    [Fact]
    public void ShouldReflect()
    {
    }
}