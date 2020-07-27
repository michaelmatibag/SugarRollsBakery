using Config.Net;

namespace SugarRollsBakery.Infrastructure.Configuration
{
    public class Configuration : IConfiguration
    {
        public T BuildFromAppConfiguration<T>() where T : class
        {
            return new ConfigurationBuilder<T>()
                .UseAppConfig()
                .Build();
        }
    }
}