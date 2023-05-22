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