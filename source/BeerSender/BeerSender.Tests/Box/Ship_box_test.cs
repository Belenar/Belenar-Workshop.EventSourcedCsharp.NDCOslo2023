namespace BeerSender.Tests.Box;

public class Ship_box_test : Box_test
{
    [Fact]
    public void When_box_is_closed_and_has_a_label_returns_success()
    {
        Given(
            Box_is_created(24),
            Beer_added_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M),
            Box_was_closed(),
            Shipping_label_added_with_carrier_and_code("PostNL", "NL123"));
        When(
            Ship_box());
        Then(
            Box_was_shipped());
    }

    [Fact]
    public void When_box_is_not_closed_returns_failure()
    {
        Given(
            Box_is_created(24),
            Beer_added_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M),
            Shipping_label_added_with_carrier_and_code("PostNL", "NL123"));
        When(
            Ship_box());
        Then(
            Box_could_not_be_shipped_because_it_was_not_closed());
    }

    [Fact]
    public void When_box_has_no_label_returns_failure()
    {
        Given(
            Box_is_created(24),
            Beer_added_to_box("Gouden Carolus", "Quadrupel Whisky Infused", 11.7M),
            Box_was_closed());
        When(
            Ship_box());
        Then(
            Box_could_not_be_shipped_because_it_has_no_label());
    }
}