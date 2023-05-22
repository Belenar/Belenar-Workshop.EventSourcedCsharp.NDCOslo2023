namespace BeerSender.Tests.Box;

public class Close_box_test : Box_test
{
    [Fact]
    public void When_box_has_beers_returns_success()
    {
        Given(
            Box_is_created(24),
            Beer_added_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M));
        When(
            Close_box());
        Then(
            Box_was_closed());
    }

    [Fact]
    public void When_box_is_empty_returns_failure()
    {
        Given(
            Box_is_created(6));
        When(
            Close_box());
        Then(
            Box_could_not_be_closed_because_it_was_empty());
    }
}