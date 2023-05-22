namespace BeerSender.Domain.Box
{
    public record Shipping_label
    {
        public Carrier Carrier { get; }
        public string Tracking_code { get; }

        // Private constructor / factory method example, for the serializer
        // Avoid breaking when the validation code changes
        private Shipping_label(Carrier carrier, string tracking_code)
        {
            Carrier = carrier;
            Tracking_code = tracking_code;
        }

        public static Shipping_label Create(string carrier, string tracking_code)
        {
            if (!Enum.TryParse<Carrier>(carrier, out var parsed_carrier))
            {
                //TODO: Should be a business exception
                throw new Exception("Invalid carrier");
            }

            switch (parsed_carrier)
            {
                case Carrier.UPS:
                    break;
                case Carrier.PostNL:
                    if (!tracking_code.StartsWith("NL"))
                        throw new Exception("Invalid tracking code");
                    break;
                case Carrier.Posten:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Shipping_label(parsed_carrier, tracking_code);
        }
    }
}

public enum Carrier
{
    UPS,
    PostNL,
    Posten
}