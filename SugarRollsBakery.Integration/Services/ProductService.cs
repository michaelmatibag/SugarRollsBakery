using SugarRollsBakery.Domain;
using SugarRollsBakery.Integration.Stripe;

namespace SugarRollsBakery.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IStripeProductService _stripeProductService;
        private readonly IStripePriceService _stripePriceService;

        public ProductService(IStripeProductService stripeProductService, IStripePriceService stripePriceService)
        {
            _stripeProductService = stripeProductService;
            _stripePriceService = stripePriceService;
        }

        public Products GetProducts()
        {
            return new Products(_stripeProductService.ListProducts(), _stripePriceService.ListPrices());
        }
    }
}