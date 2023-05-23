using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box;

public class Box_size
{
    public int Number_of_bottles { get; init; }

    private Box_size()
    {
    }

    private Box_size(int number_of_bottles)
    {
        Number_of_bottles = number_of_bottles;
    }

    public static Box_size Create(int number_of_bottles)
    {
        switch (number_of_bottles)
        {
            case 6:
            case 12:
            case 24:
                return new(number_of_bottles);
        }

        throw new Box_size_exception(Fail_reason.Invalid_box_size);
    }
}