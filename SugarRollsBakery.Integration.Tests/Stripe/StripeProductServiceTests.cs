using NUnit.Framework;
using Shouldly;
using Stripe;
using SugarRollsBakery.Infrastructure.Configuration;
using SugarRollsBakery.Integration.Stripe;

namespace SugarRollsBakery.Integration.Tests.Stripe
{
    [TestFixture]
    public class StripeProductServiceTests
    {
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {
            StripeConfiguration.ApiKey = new Configuration().BuildFromAppConfiguration<IStripeConfiguration>().ApiKey;
            _productService = new ProductService();
        }

        [Test, Explicit]
        public void ListProducts_Returns_Products()
        {
            //Arrange
            var service = new StripeProductService(_productService);

            //Act
            var products = service.ListProducts();

            //Assert
            products.Data.Count.ShouldBe(3);
            products.Data[0].Name.ShouldBe("Ube Yema Cake");
        }
    }
}