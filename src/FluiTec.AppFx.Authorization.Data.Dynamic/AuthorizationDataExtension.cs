using FluiTec.AppFx.Authorization.Data.Dynamic;
using FluiTec.AppFx.Authorization.Data.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>   An authorization data extension. </summary>
    public static class AuthorizationDataExtension
    {
        /// <summary>
        ///     An IServiceCollection extension method that configure identity data service.
        /// </summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="migrate">          (Optional) True to migrate.</param>
        /// <returns>   An IServiceCollection. </returns>
        public static IServiceCollection ConfigureAuthorizationDataService(this IServiceCollection services,
            IConfigurationRoot configuration, bool migrate = true)
        {
            var provider = new AuthorizationDataProvider(configuration.GetConfiguration<AuthorizationDataOptions>());
            services.AddSingleton(p => provider.GetDataService(configuration));

            if (migrate)
            {
                var dataService = provider.GetDataService(configuration);
                if (dataService.CanMigrate())
                    dataService.Migrate();
            }

            return services;
        }
    }
}