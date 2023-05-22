namespace BeerSender.Domain.Box
{
    public record Box_selected(Box_size Box_size);
    public record Box_failed_to_select_box(Exceptions.Box_size_exception.Reason Reason);

    public record Box_closed();
    public record Could_not_close_box(Exceptions.Box_close_exception.Reason Reason);
    
    public record Box_shipped();
    public record Could_not_ship_box(Exceptions.Box_ship_exception.Reason Reason);
    
    public record Added_beer_to_box();

    public record Fail_to_add_beer_to_box();
}

