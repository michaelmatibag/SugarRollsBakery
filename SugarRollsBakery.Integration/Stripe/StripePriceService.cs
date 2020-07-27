using Stripe;

namespace SugarRollsBakery.Integration.Stripe
{
    public class StripePriceService : IStripePriceService
    {
        private readonly PriceService _priceService;

        public StripePriceService(PriceService priceService)
        {
            _priceService = priceService;
        }

        public StripeList<Price> ListPrices()
        {
            return _priceService.List();
        }
    }
}