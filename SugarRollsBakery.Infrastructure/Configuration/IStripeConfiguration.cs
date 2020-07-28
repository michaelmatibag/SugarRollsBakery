using Config.Net;

namespace SugarRollsBakery.Infrastructure.Configuration
{
    public interface IStripeConfiguration
    {
        [Option(Alias = "StripeConfiguration.ApiKey")]
        string ApiKey { get; }
    }
}