using AutoFixture;
using FluentAssertions;
using JuniperTechnical.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JuniperTechnical.Tests
{
    public class ServiceTests
    {
        private readonly IFixture _fixture;
        private readonly TaxService _taxService;
        
        public ServiceTests()
        {
            _fixture = new Fixture();
            _taxService = new TaxService();
        }

        [Fact]
        public async Task GetRatesForLocation_Success()
        {
            var location = new LocationRequest { Zip = "53144" };
            var result = await _taxService.GetRatesForLocation(location);

            result.Should().NotBeNull();
            result.State.Should().BeEquivalentTo("WI");
            result.Zip.Should().Be("53144");
            result.Country.Should().Be("US");
            result.County.Should().Be("KENOSHA");
        }

        [Fact]
        public async Task GetRatesForLocation_Fail()
        {
            var location = new LocationRequest { Zip = "asdf" };
            var result = await _taxService.GetRatesForLocation(location);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetTaxForOrder_Success()
        {
            NexusAddress address = new NexusAddress
            {
                id = "Main Location",
                country = "US",
                zip = "92093",
                state = "CA",
                city = "La Jolla",
                street = "9500 Gilman Drive"
            };
            var addresses = new List<NexusAddress> { address };

            OrderLineItem lineItem = new OrderLineItem
            {
                id = "1",
                quantity = 1,
                product_tax_code = "20010",
                unit_price = 15,
                discount = 0
            };
            var orders = new List<OrderLineItem> { lineItem };

            var order = new OrderRequest()
            {
                from_country = "US",
                from_zip = "92093",
                from_state = "CA",
                from_city = "La Jolla",
                from_street = "9500 Gilman Drive",
                to_country = "US",
                to_zip = "90002",
                to_state = "CA",
                to_city = "Los Angeles",
                to_street = "1335 E 103rd St",
                amount = 15,
                shipping = 1.5,
                nexus_addresses = addresses,
                line_items = orders
            };
            var result = await _taxService.GetTaxForOrder(order);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetTaxForOrder_Fail()
        {
            var order = new OrderRequest() { from_country = "US" };
            var result = await _taxService.GetTaxForOrder(order);

            result.Should().BeNull();
        }
    }
}
