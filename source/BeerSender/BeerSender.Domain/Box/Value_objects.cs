using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box;

public record Shipping_label
{
    public Carrier Carrier { get; }
    public string Tracking_code { get; }

    private Shipping_label(Carrier carrier, string tracking_code)
    {
        Carrier = carrier;
        Tracking_code = tracking_code;
    }

    public static Shipping_label Create (string carrier, string tracking_code)
    {
        if (!Enum.TryParse<Carrier>(carrier, out var carrier_enum))
        {
            // TODO: Maybe should be a business exception?
            throw new Exception("Invalid carrier.");
        }

        switch (carrier_enum)
        {
            case Carrier.PostNL:
                if (!tracking_code.StartsWith("NL"))
                    throw new Exception("Invalid tracking code");
                break;
        }

        return new(carrier_enum, tracking_code);
    }
}

public enum Carrier
{
    UPS,
    PostNL,
    Posten
}

public record Box_id(int Id)
{
    private static int currentId = 0;

    public static Box_id Next()
    {
        currentId += 1;
        return new Box_id(currentId);
    }
}

public class Box_size
{
    public int Number_of_bottles { get; }

    private Box_size(int number_of_bottles)
    {
        Number_of_bottles = number_of_bottles;
    }

    public static Box_size Create(int number_of_bottles)
    {
        switch (number_of_bottles)
        {
            case 6:
            case 12:
            case 24:
                return new(number_of_bottles);
        }

        throw new Box_size_exception(Box_size_exception.Fail_reason.Invalid_box_size);
    }
}

public record Beer_bottle(string Name);
