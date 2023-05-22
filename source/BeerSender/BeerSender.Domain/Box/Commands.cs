namespace BeerSender.Domain.Box.Commands;

public readonly record struct Select_box_size(int Number_of_bottles);

public readonly record struct Add_shipping_label(Guid Box_id, string Carrier, string Tracking_code);

// Howto check "Box is full?"
public readonly record struct Add_beer_to_box(Guid Box_id, string Name);

// Howto check "Beer in box?"
public readonly record struct Close_box(Guid Box_id);

public readonly record struct Ship_box(Guid Box_id);