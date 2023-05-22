namespace BeerSender.Domain.Box.Exceptions;

public class Box_size_exception : Exception
{
    public Reason ErrorReason { get; }

    public Box_size_exception(Reason errorReason)
    {
        ErrorReason = errorReason;
    }
    public enum Reason
    {
        Invalid_box_size
    }
}

public class Box_close_exception : Exception
{
    public Reason ErrorReason { get; }

    public Box_close_exception(Reason errorReason)
    {
        ErrorReason = errorReason;
    }

    public enum Reason
    {
        Box_is_not_full,
        Box_is_tool_full,
        Box_is_broken
    }
}


public class Box_ship_exception : Exception
{
    public Reason ErrorReason { get; }

    public Box_ship_exception(Reason errorReason)
    {
        ErrorReason = errorReason;
    }

    public enum Reason
    {
        Box_is_not_ready,
    }
}
