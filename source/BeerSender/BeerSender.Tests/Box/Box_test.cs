using BeerSender.Domain.Box;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Tests.Box;

public class Box_test : Command_test
{
    private readonly Guid _aggregate_id = Guid.NewGuid();

    //Commands
    protected Domain.Box.Commands.Select_box_size Select_box_size_with_valid_number_of_bottles()
    {
        return new Domain.Box.Commands.Select_box_size(_aggregate_id, 24);
    }


    //Events
    protected Box_created Box_is_created()
    {
        return new Box_created(Box_size.Create(24));
    }
}