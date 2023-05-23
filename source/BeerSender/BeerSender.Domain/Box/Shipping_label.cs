using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Domain.Box;

public class Shipping_label
{
    public Carrier Carrier { get; private set; }
    public string Tracking_code { get; private set; }

    private Shipping_label()
    {
    }

    private Shipping_label(Carrier carrier, string tracking_code)
    {
        Carrier = carrier;
        Tracking_code = tracking_code;
    }

    public static Shipping_label Create (string carrier, string tracking_code)
    {
        if (!Enum.TryParse<Carrier>(carrier, out var carrier_enum))
        {
            throw new Shipping_label_exception(
                Fail_reason.Invalid_carrier);
        }

        switch (carrier_enum)
        {
            case Carrier.PostNL:
                if (!tracking_code.StartsWith("NL"))
                    throw new Shipping_label_exception(
                        Fail_reason.Invalid_tracking_code);
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