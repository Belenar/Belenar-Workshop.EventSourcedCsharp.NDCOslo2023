namespace BeerSender.Domain.Box;

public record Select_box_type(int Number_of_bottles);

public record Close_box();

public record Ship_box();

public record Add_shipping_label_to_box(Shipping_label Shipping_label);

public record Add_beer_to_box(Beer beer);
