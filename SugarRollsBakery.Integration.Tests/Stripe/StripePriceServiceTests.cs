using NUnit.Framework;
using Shouldly;
using Stripe;
using SugarRollsBakery.Infrastructure.Configuration;
using SugarRollsBakery.Integration.Stripe;

namespace SugarRollsBakery.Integration.Tests.Stripe
{
    [TestFixture]
    public class StripePriceServiceTests
    {
        private PriceService _priceService;

        [SetUp]
        public void Setup()
        {
            StripeConfiguration.ApiKey = new Configuration().BuildFromAppConfiguration<IStripeConfiguration>().ApiKey;
            _priceService = new PriceService();
        }

        [Test, Explicit]
        public void ListPrices_Returns_Prices()
        {
            //Arrange
            var service = new StripePriceService(_priceService);

            //Act
            var prices = service.ListPrices();

            //Assert
            prices.Data.Count.ShouldBe(3);
            prices.Data[0].UnitAmountDecimal.ShouldBe(800);
        }
    }
}