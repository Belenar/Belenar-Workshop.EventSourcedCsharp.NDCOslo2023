using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box.Events;

public record Box_created(Box_size Size);

public record Box_failed_to_create(Box_size_exception Reason);
