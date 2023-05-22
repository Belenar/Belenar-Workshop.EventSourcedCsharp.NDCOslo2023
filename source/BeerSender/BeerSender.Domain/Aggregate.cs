namespace BeerSender.Domain;

internal interface Aggregate
{
    void Apply(object @event);
}