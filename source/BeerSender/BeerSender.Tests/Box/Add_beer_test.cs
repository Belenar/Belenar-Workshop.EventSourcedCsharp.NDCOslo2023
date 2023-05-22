namespace BeerSender.Tests.Box;

public class Add_beer_test : Box_test
{
    [Fact]
    public void When_box_is_not_full_returns_success()
    {
        Given(
            Box_is_created(24));
        When(
            Add_beer_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M));
        Then(
            Beer_added_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M));
    }

    [Fact]
    public void When_box_is_full_returns_failure()
    {
        Given(
            Box_is_created(6),
            Beer_added_to_box("Beer4Nature", "Hert", 6.7M),
            Beer_added_to_box("Beer4Nature", "Hert", 6.7M),
            Beer_added_to_box("Beer4Nature", "Hert", 6.7M),
            Beer_added_to_box("Beer4Nature", "Hert", 6.7M),
            Beer_added_to_box("Beer4Nature", "Hert", 6.7M),
            Beer_added_to_box("Beer4Nature", "Hert", 6.7M));
        When(
            Add_beer_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M));
        Then(
            Beer_could_not_be_added_because_box_was_full());
    }

    [Fact]
    public void When_box_is_has_no_size_returns_failure()
    {
        Given();
        When(
            Add_beer_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M));
        Then(
            Beer_could_not_be_added_because_box_has_no_size());
    }
}