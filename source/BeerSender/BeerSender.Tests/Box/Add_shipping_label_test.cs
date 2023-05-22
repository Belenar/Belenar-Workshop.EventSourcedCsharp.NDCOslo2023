namespace BeerSender.Tests.Box;

public class Add_shipping_label_test : Box_test
{
    [Theory]
    [InlineData("PostNL", "NL123")]
    [InlineData("UPS", "Any_code")]
    [InlineData("Posten", "Any_code")]
    public void When_label_is_valid_returns_success(string carrier, string tracking_code)
    {
        Given(
            Box_is_created(24));
        When(
            Add_shipping_label(carrier, tracking_code));
        Then(
            Shipping_label_added_with_carrier_and_code(carrier, tracking_code));
    }

    [Fact]
    public void When_carrier_is_invalid_returns_failure()
    {
        Given(
            Box_is_created(24));
        When(
            Add_shipping_label("BPost", "Any_code"));
        Then(
            Shipping_label_could_not_be_created_with_invalid_carrier());
    }

    [Fact]
    public void When_tracking_code_is_invalid_returns_failure()
    {
        Given(
            Box_is_created(24));
        When(
            Add_shipping_label("PostNL", "Any_code"));
        Then(
            Shipping_label_could_not_be_created_with_invalid_code());
    }
}