using System.Linq;
using FluiTec.AppFx.Authorization.Models;
using FluiTec.AppFx.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Authorization.Api
{
    /// <summary>   An authorization API extension. </summary>
    public static class AuhorizationApiExtension
    {
        /// <summary>   An IServiceCollection extension method that configure authorization API. </summary>
        /// <param name="services">             The services to act on. </param>
        /// <param name="configuration">        Name of the configuration. </param>
        /// <param name="configurationName">    (Optional) Name of the config entry. </param>
        /// <returns>   An IServiceCollection. </returns>
        public static IServiceCollection ConfigureAuthorizationApi(this IServiceCollection services,
            IConfigurationRoot configuration, string configurationName = "AuthorizationServiceOptions")
        {
            var options = configuration.GetConfiguration<AuthorizationServiceOptions>(configurationName);
            services.AddSingleton(options);
            services.AddMemoryCache();
            services.AddScoped<AuthorizationService>();
            var provider = services.BuildServiceProvider();
            if (options.SynchronizeActivities)
                SynchronizeAuthorizationActivities(provider.GetRequiredService<AuthorizationService>(), options);
            services.AddScoped<IAuthorizationHandler, AuhtorizedForActionHandler>();
            services.AddAuthorizationCore(aOptions =>
            {
                foreach (var o in options.Activities)
                    aOptions.AddPolicy(o,
                        builder => { builder.Requirements.Add(new AuhtorizedForActionRequirement(o)); });
            });
            return services;
        }

        /// <summary>   Synchronizes the authorization activities. </summary>
        /// <param name="service">  The service. </param>
        /// <param name="options">  Options for controlling the operation. </param>
        public static void SynchronizeAuthorizationActivities(AuthorizationService service,
            AuthorizationServiceOptions options)
        {
            var apiExisting = service.Activities.GetAll().Result.Select(a => a.Name);
            foreach (var activity in options.Activities.Where(a => !apiExisting.Contains(a)))
            {
                var a = service.Activities.Add(new ActivityModel {Name = activity}).Result;
            }
        }
    }
}