using BeerSender.Domain.Box;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Tests.Box;

public class Box_test : Command_test
{
    private readonly Guid _aggregate_id = Guid.NewGuid();
    private string _brewery = "NDC";
    private string _name = "NDC Pale Ale";
    private decimal _percentage = 5.5m;

    //Commands
    protected Domain.Box.Commands.Select_box_size Select_box_size_with_valid_number_of_bottles(
        int number_of_bottles)
    {
        return new Domain.Box.Commands.Select_box_size(_aggregate_id, number_of_bottles);
    }

    protected Domain.Box.Commands.Add_beer_to_box Add_beer_to_box()
    {
        return new Domain.Box.Commands.Add_beer_to_box(_aggregate_id, _brewery, _name, _percentage);
    }


    //Events
    protected Box_created Box_is_created(int number_of_bottles = 6)
    {
        return new Box_created(Box_size.Create(number_of_bottles));
    }

    protected Beer_added_to_box Beer_is_added_to_box()
    {
        return new Beer_added_to_box(new Beer_bottle(_brewery, _name, _percentage));
    }
}