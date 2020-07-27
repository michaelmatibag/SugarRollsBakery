using NUnit.Framework;
using Stripe;
using SugarRollsBakery.Infrastructure.Configuration;
using SugarRollsBakery.Integration.Stripe;
using SugarRollsBakery.Integration.Tests.Stripe;

namespace SugarRollsBakery.Domain.Tests
{
    [TestFixture]
    public class ProductsTests
    {
        private ProductService _productService;
        private PriceService _priceService;

        [SetUp]
        public void Setup()
        {
            StripeConfiguration.ApiKey = new Configuration().BuildFromAppConfiguration<IStripeConfiguration>().ApiKey;
            _productService = new ProductService();
            _priceService = new PriceService();
        }

        [Test, Explicit]
        public void BuildProducts_Builds_Products()
        {
            //Arrange
            var productService = new StripeProductService(_productService);
            var priceService = new StripePriceService(_priceService);

            //Act
            var products = new Products(productService.ListProducts(), priceService.ListPrices());
        }
    }
}