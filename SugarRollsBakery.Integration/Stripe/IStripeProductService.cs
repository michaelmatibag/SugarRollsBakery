using Stripe;

namespace SugarRollsBakery.Integration.Stripe
{
    public interface IStripeProductService
    {
        StripeList<Product> ListProducts();
    }
}