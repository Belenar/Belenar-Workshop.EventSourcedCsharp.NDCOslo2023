namespace BeerSender.Domain;

public interface Aggregate
{
    void Apply(object @event);
}