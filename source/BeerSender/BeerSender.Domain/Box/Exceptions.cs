namespace BeerSender.Domain.Box.Exceptions;

public class Box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Box_exception(Fail_reason reason)
    {
        Reason = reason;
    }
}

public class Shipping_label_exception : Exception
{
    public Fail_reason Reason { get; }

    public Shipping_label_exception(Fail_reason reason)
    {
        Reason = reason;
    }
}

public enum Fail_reason
{
    Invalid_box_size,
    Empty_box,
    Box_not_ready,
    Invalid_beer_name,
    Invalid_carrier,
    Invalid_tracking_code,
}

public class Beer_exception : Exception
{
    public Fail_reason Reason { get; }

    public Beer_exception(Fail_reason reason)
    {
        Reason = reason;
    }
}