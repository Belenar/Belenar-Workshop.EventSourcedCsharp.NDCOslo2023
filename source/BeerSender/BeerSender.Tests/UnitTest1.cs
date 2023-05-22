using BeerSender.Domain.Box;
using BeerSender.Domain.Box.Exceptions;

namespace BeerSender.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Shipping_label_test()
        {
            var expected_tracking_code = "Whatever";
            var expected_carrier = "UPS";

            var label = new Shipping_label(expected_carrier, expected_tracking_code);
            Assert.Equal(Carriers.UPS, label.Carrier);

            var (carrier, tracking_code) = label;
            Assert.Equal(expected_carrier, carrier);
            Assert.Equal(expected_tracking_code, tracking_code);
        }

        [Fact]
        public void Beer_test()
        {
            var beer = new Beer("Super", Beer_size.cl_330);
            var (name, size) = beer;

            Assert.Equal(Beer_size.cl_330, size);
            Assert.Equal("Super", name);
        }

        [Fact]
        public void Box_size_test()
        {
            var beer = () => new Box_size(1000);
            Assert.Throws<Box_size_exception>(beer);
        }
    }
}