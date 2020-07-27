using Stripe;

namespace SugarRollsBakery.Integration.Stripe
{
    public class StripeProductService : IStripeProductService
    {
        private readonly ProductService _productService;

        public StripeProductService(ProductService productService)
        {
            _productService = productService;
        }

        public StripeList<Product> ListProducts()
        {
            return _productService.List();
        }
    }
}