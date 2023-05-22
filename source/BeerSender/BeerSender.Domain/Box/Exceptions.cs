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