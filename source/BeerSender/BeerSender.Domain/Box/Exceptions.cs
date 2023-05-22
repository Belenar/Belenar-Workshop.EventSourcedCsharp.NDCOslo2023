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