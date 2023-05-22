namespace BeerSender.Tests.Box;

public class Select_box_size_test : Box_test
{
    [Theory]
    [InlineData(6)]
    [InlineData(12)]
    [InlineData(24)]
    public void When_size_is_valid_returns_success(int number_of_bottles)
    {
        Given();
        When(
            Select_box_size_with_number_of_bottles(number_of_bottles));
        Then(
            Box_is_created(number_of_bottles));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(23)]
    public void When_size_is_invalid_returns_failure(int number_of_bottles)
    {
        Given();
        When(
            Select_box_size_with_number_of_bottles(number_of_bottles));
        Then(
            Box_could_not_be_created());
    }
}