namespace BeerSender.Domain.Box
{

    
    public record Box_selected(Box_size Box_size);
    public record Box_failed_to_select_box(BoxException Ex);

    public record Box_closed;
    public record Could_not_close_box(BoxException ex);

    public record Box_label_added(Shipping_label Shipping_label);
    public record Could_not_create_label(BoxException Ex);
    
    public record Box_shipped(Shipment_identifier Shipment_identifier);

    public record Could_not_ship_box(BoxException Ex);
    
    public record Added_beer_to_box;
    public record Fail_to_add_beer_to_box(BoxException Ex);
    
    
}

