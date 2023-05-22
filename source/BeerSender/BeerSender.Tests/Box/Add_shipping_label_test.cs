using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Tests.Box;

public class Add_shipping_label_test : Box_test
{
    [Theory]
    [InlineData("UPS", "1Z9999999999999999")]
    [InlineData("PostNL", "NL999999999999")]
    [InlineData("Posten", "9999 9999 9999 9999 9999 99")]
    public void When_carrier_and_tracking_code_is_valid_returns_success(string carrier, string tracking_code)
    {
        Given();
        When(
            Add_shipping_label_with_carrier_and_tracking_code(carrier, tracking_code));
        Then(
            Shipping_label_is_added(carrier, tracking_code));
    }
    
    [Theory]
    [InlineData("DPD", "x")]
    [InlineData("", "")]
    public void When_carrier_is_invalid_returns_failure(string carrier, string tracking_code)
    {
        Given();
        When(
            Add_shipping_label_with_carrier_and_tracking_code(carrier, tracking_code));
        Then(
            Add_shipping_label_has_failed(Fail_reason.Invalid_carrier));
    }

    [Theory]
    [InlineData("UPS", "")]
    [InlineData("PostNL", "999999999999")]
    public void When_tracking_code_is_invalid_returns_failure(string carrier, string tracking_code)
    {
        Given();
        When(
            Add_shipping_label_with_carrier_and_tracking_code(carrier, tracking_code));
        Then(
            Add_shipping_label_has_failed(Fail_reason.Invalid_tracking_code));
    }
}