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

public enum Box_close_reason
{
    Box_is_not_full,
    Box_is_tool_full,
    Box_is_broken
}

public enum Box_ship_reason
{
    Box_is_not_ready,
}
public enum Box_label_reason
{
    Label_is_not_valid,
}

public enum Box_add_reason
{
    Box_is_full,
    Box_is_broken
}
