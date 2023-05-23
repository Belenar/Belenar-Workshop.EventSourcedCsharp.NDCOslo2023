namespace BeerSender.Web.Projections;

public class Projection_service<TProjection> : BackgroundService
where TProjection : Projection
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}

public interface Projection
{

}