using Config.Net;

namespace SugarRollsBakery.Infrastructure.Tests.Configuration
{
    public interface ITestConfiguration
    {
        [Option(Alias = "Configuration.TestKey")]
        string ConfigurationTest { get; }
    }
}