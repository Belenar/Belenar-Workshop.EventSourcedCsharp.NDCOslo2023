namespace BeerSender.Tests.Box;

public class Add_beer_to_box_test : Box_test
{
    [Fact]
    public void Add_beer_to_box_when_box_has_been_created_should_be_valid()
    {
        Given(Box_is_created());
        When(Add_beer_to_box());
        Then(Beer_is_added_to_box());
    }
}