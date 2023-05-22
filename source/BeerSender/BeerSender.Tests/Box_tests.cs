using BeerSender.Domain.Box;

namespace BeerSender.Tests;

public class Box_tests : Command_test
{
    protected readonly Guid aggregateId = new ();

    protected Select_box_size select_valid_box_size()
    {
        return new Select_box_size(aggregateId, 24);
    }
    
    protected static Box_selected Valid_box_selected()
    {
        return new Box_selected(new Box_size(24));
    }

}

public class Select_box_size_tests : Box_tests
{
    [Fact]
    public void Valid_size_should_be_OK()
    {
        Given();
        When(select_valid_box_size());
        Then(Valid_box_selected());
    }
}

