namespace BeerSender.Domain.Box.Commands;

public record Select_box_size(int Number_of_bottles);

public record Add_shipping_label(Guid BoxId, Shipping_label Shipping_label);

public record Add_beer_to_box(Guid BoxId);

public record Close_box(Guid BoxId);

public record Ship_box(Guid BoxId);
