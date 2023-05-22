using BeerSender.Domain.Box;

namespace BeerSender.Tests;

public class Select_box_size_tests : Box_tests
{
    [Theory]
    [InlineData(6)]
    [InlineData(12)]
    [InlineData(24)]
    public void Valid_size_should_be_OK(int numberOfBottles)
    {
        Given();
        When(select_box_size(numberOfBottles));
        Then(Box_selected(numberOfBottles));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(7)]
    public void InValid_size_should_not_be_OK(int numberOfBottles)
    {
        Given();
        When(select_box_size(numberOfBottles));
        Then(new Box_failed_to_select_box(Box_select_reason.Invalid_box_size));
    }
}