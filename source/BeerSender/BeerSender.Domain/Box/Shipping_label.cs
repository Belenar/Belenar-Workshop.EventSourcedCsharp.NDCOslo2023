namespace BeerSender.Domain.Box;
public record Shipping_label
{
    public Shipping_label(string carrier, string tracking_code)
    {
        if (!Enum.TryParse<Carriers>(carrier, out var carriers))
            throw new ArgumentOutOfRangeException(nameof(carrier));
        
        Carrier = carriers;
        Tracking_code = tracking_code;
    }

    public Carriers Carrier { get; }
    public string Tracking_code { get; }

    public void Deconstruct(out string carrier, out string tracking_code)
    {
        carrier = Carrier.ToString();
        tracking_code = Tracking_code;
    }
}

public enum Carriers
{
    UPS,
    PostNL,
    Posten
}