using Stripe;

namespace SugarRollsBakery.Integration.Stripe
{
    public interface IStripePriceService
    {
        StripeList<Price> ListPrices();
    }
}