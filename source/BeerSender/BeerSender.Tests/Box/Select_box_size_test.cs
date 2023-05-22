namespace BeerSender.Tests.Box;

public class Select_box_size_test : Box_test
{
    [Theory]
    [InlineData(6)]
    [InlineData(12)]
    [InlineData(24)]
    public void When_size_is_valid_returns_success(int number_of_bottles)
    {
        // Given: Events from the past
        // When: Command is executed
        // Then: Specific events should occur

        Given();
        When(Select_box_size_with_valid_number_of_bottles(number_of_bottles));
        Then(Box_is_created(number_of_bottles));
    }
}