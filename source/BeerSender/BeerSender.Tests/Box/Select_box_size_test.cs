namespace BeerSender.Tests.Box;

public class Select_box_size_test : Box_test
{
    [Fact]
    public void When_size_is_valid_returns_success()
    {
        // Given: Events from the past
        // When: Command is executed
        // Then: Specific events should occur

        Given();
        When(Select_box_size_with_valid_number_of_bottles());
        Then(Box_is_created());
    }
}