using BeerSender.Domain.Box;
using BeerSender.Domain.Box.Commands;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Tests.Box;

public class Box_test : Command_test
{
    private readonly Guid _aggregate_id = Guid.NewGuid();

    // Commands
    protected Select_box_size Select_box_size_with_number_of_bottles(
        int number_of_bottles)
    {
        return new Select_box_size(_aggregate_id, number_of_bottles);
    }

    // Events
    protected Box_created Box_is_created(int number_of_bottles)
    {
        return new Box_created(Box_size.Create(number_of_bottles));
    }
}