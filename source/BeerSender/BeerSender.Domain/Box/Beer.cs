using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box;

public class Beer
{
    public string Name { get; }
    
    private Beer(string name)
    {
        Name = name;
    }

    public static Beer Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Beer_exception(Beer_exception.Fail_reason.Invalid_beer_name);
        }

        return new Beer(name);
    }
}