using Config.Net;

namespace SugarRollsBakery.Integration.Tests.Stripe
{
    public interface IStripeConfiguration
    {
        [Option(Alias = "StripeConfiguration.ApiKey")]
        string ApiKey { get; }
    }
}