namespace BeerSender.Domain.Box;

public record Event;

public record Box_selected(Box_size Box_size) : Event;

public record Box_failed_to_select_box(Box_select_reason Reason) : Event;

public record Box_closed : Event;

public record Could_not_close_box(Box_close_failed_reason Reason) : Event;

public record Label_added_to_box(Label _Label) : Event;

public record Could_not_create_label(Box_label_failed_reason Reason) : Event;

public record Box_shipped(Shipment_identifier Shipment_identifier) : Event;

public record Could_not_ship_box(Box_ship_failed_reason Reason) : Event;

public record Beer_added_to_box(Beer beer) : Event;

public record Could_not_add_beer_to_box(Box_add_failed_reason Reason) : Event;