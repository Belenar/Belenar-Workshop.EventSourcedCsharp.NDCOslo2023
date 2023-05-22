namespace BeerSender.Domain.Box.Exceptions;

public class Box_exception : Exception
{
    private readonly Fail_reason _reason;

    public Box_exception(Fail_reason reason)
    {
        _reason = reason;
    }

    public enum Fail_reason
    {
        Invalid_box_size,
        Empty_box,
        Box_not_ready
    }
}

public class Beer_exception : Exception
{
    private readonly Fail_reason _reason;

    public Beer_exception(Fail_reason reason)
    {
        _reason = reason;
    }

    public enum Fail_reason
    {
        Invalid_beer_name
    }
}