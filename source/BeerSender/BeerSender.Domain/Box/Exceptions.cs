namespace BeerSender.Domain.Box.Exceptions;

public class Box_size_exception : Exception
{
    private readonly Fail_reason _reason;

    public Box_size_exception(Fail_reason reason)
    {
        _reason = reason;
    }

    public enum Fail_reason
    {
        Invalid_box_size
    }
}

public class Add_beer_bottle_exception : Exception
{
    private readonly Fail_reason _reason;

    public Add_beer_bottle_exception(Fail_reason reason)
    {
        _reason = reason;
    }

    public enum Fail_reason
    {
        Bottle_too_high,
        Bottle_too_wide,
        Bottle_was_drunk_while_adding_to_box,
    }
}
public class Box_close_failed_exception : Exception
{
    private readonly Fail_reason _reason;

    public Box_close_failed_exception(Fail_reason fail_Reason)
    {
        _reason = fail_Reason;
    }

    public enum Fail_reason
    {
        Too_many_bottles_in_box,
        Out_of_tape,
        Box_broken,
    }
}