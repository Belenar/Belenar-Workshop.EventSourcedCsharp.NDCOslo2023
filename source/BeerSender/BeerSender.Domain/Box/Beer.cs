namespace BeerSender.Domain.Box;

public record Beer(string name, Beer_size Beer_sizeize);

public enum Beer_size
{
    cl_330 = 330,
    cl_500 = 500
}