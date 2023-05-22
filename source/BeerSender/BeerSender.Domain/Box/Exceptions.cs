namespace BeerSender.Domain.Box.Exceptions;

public class Box_size_exception : Exception
{
    public Fail_reason Reason { get; }

    public Box_size_exception(Fail_reason reason)
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

public class Add_beer_to_box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Add_beer_to_box_exception(Fail_reason reason)
    {
        Reason = reason;
    }
}

public class Close_box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Close_box_exception(Fail_reason reason)
    {
        Reason = reason;
    }
}

public class Ship_box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Ship_box_exception(Fail_reason reason)
    {
        Reason = reason;
    }
}

public enum Fail_reason
{
    Invalid_box_size,
    Invalid_carrier,
    Invalid_tracking_code,
    Box_has_no_size,
    Box_is_full,
    Box_is_empty,
    Box_has_no_label,
    Box_is_not_closed
}
