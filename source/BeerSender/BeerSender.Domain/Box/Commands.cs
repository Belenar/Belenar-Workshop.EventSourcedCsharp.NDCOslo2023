namespace BeerSender.Domain.Box.Commands;

public record Select_box_size(Box_id Box_id, int Number_of_bottles);

public record Add_shipping_label(string Shipping_address);

public record Add_beer_to_box(Box_id Box_id);

public record Close_box(Box_id Box_id);
