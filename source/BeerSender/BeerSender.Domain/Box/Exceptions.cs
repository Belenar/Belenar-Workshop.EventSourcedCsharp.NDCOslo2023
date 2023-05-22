namespace BeerSender.Domain.Box.Exceptions;

public class Box_size_exception : Exception
{
    public Fail_reason Reason { get; }

    public Box_size_exception(Fail_reason reason)
    {
        Reason = reason;
    }

    public enum Fail_reason
    {
        Invalid_box_size
    }
}

public class Add_beer_to_box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Add_beer_to_box_exception(Fail_reason reason)
    {
        Reason = reason;
    }

    public enum Fail_reason
    {
        Too_many_beers
    }
}

public class Close_box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Close_box_exception(Fail_reason reason)
    {
        Reason = reason;
    }

    public enum Fail_reason
    {
        Box_is_empty
    }
}

public class Ship_box_exception : Exception
{
    public Fail_reason Reason { get; }

    public Ship_box_exception(Fail_reason reason)
    {
        Reason = reason;
    }

    public enum Fail_reason
    {
        Missing_label,
        Box_not_closed
    }
}