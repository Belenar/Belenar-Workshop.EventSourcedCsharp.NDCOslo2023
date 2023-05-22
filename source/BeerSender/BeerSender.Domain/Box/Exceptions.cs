namespace BeerSender.Domain.Box;

public class BoxException : Exception
{
    public readonly string Reason;

    public BoxException(string reason)
    {
        Reason = reason;
    }
}

public enum Box_select_reason
{
    Invalid_box_size
}

public enum Box_close_failed_reason
{
    Box_is_not_full,
    Box_is_too_full
}

public enum Box_ship_failed_reason
{
    Box_is_not_ready
}

public enum Box_label_failed_reason
{
    Label_is_not_valid
}

public enum Box_add_failed_reason
{
    Box_is_full,
    Box_is_broken
}