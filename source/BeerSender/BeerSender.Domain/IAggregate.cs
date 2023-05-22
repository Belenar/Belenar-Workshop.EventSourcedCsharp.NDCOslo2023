namespace BeerSender.Domain;

public interface IAggregate
{
    void Apply(object @event);
}