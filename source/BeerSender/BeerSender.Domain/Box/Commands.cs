namespace BeerSender.Domain.Box.Commands;

public record Select_box_size(int Number_of_bottles);
public record Add_shipping_label(Shipping_label Shipping_Label);
public record Add_beer_to_box(Beer_bottle Beer_Bottle);
public record Close_box();
public record Ship_box(Carrier Carrier);