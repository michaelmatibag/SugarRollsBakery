using NUnit.Framework;
using Shouldly;
using SugarRollsBakery.Infrastructure.Configuration;
using SugarRollsBakery.Infrastructure.Services;
using SugarRollsBakery.Integration.Stripe;
using SugarRollsBakery.Integration.Tests.Stripe;
using StripeNet = Stripe;

namespace SugarRollsBakery.Integration.Tests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IStripeProductService _stripeProductService;
        private IStripePriceService _stripePriceService;

        [SetUp]
        public void Setup()
        {
            StripeNet.StripeConfiguration.ApiKey = new Configuration().BuildFromAppConfiguration<IStripeConfiguration>().ApiKey;
            _stripeProductService = new StripeProductService(new StripeNet.ProductService());
            _stripePriceService = new StripePriceService(new StripeNet.PriceService());
        }

        [Test, Explicit]
        public void GetProducts_Returns_Products()
        {
            //Arrange
            var productService = new ProductService(_stripeProductService, _stripePriceService);

            //Act
            var products = productService.GetProducts();

            //Assert
            products.Items.Count.ShouldBe(3);
            products.Items[0].Price.ShouldBe(8);
        }
    }
}