using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluiTec.AppFx.Authorization.Models;
using FluiTec.AppFx.Rest;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace FluiTec.AppFx.Authorization.Api.Api
{
    /// <summary>   An authorization actions api. </summary>
    public class AuthorizationActivitiesApi : CachingDefaultJsonApi<ActivityModel>
    {
        /// <summary>   Constructor. </summary>
        /// <param name="service">  The service. </param>
        /// <param name="subPath">  Full pathname of the sub file. </param>
        /// <param name="cache">    The cache. </param>
        public AuthorizationActivitiesApi(IWebService service, string subPath, IMemoryCache cache) : base(service,
            subPath, cache)
        {
        }

        // <summary>   Deletes the given ID. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="model">    The model to add. </param>
        /// <returns>   An asynchronous result. </returns>
        public override async Task Delete(ActivityModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            await Delete(model.Id);
        }

        /// <summary>   Is authorized. </summary>
        /// <param name="activity">     The activity. </param>
        /// <param name="userEmail">    The users email. </param>
        /// <returns>   An asynchronous result that yields true if authorized, false if not. </returns>
        public async Task<bool> IsAuthorized(string activity, string userEmail)
        {
            var key = $"{ModelTypeName}.{activity}.{userEmail}";
            if (Cache.TryGetValue(key, out bool entry)) return entry;

            var options =
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(
                    new DateTimeOffset(DateTime.Now.Add(CacheExpiration)));
            entry = await IsAuthorizedWeb(activity, userEmail);
            Cache.Set(key, entry, options);

            return entry;
        }

        /// <summary>   Is authorized. </summary>
        /// <param name="activity">     The activity. </param>
        /// <param name="userEmail">    The users email. </param>
        /// <returns>   An asynchronous result that yields true if authorized, false if not. </returns>
        public async Task<bool> IsAuthorizedWeb(string activity, string userEmail)
        {
            var client = await BuildClient();
            var content =
                new StringContent(
                    JsonConvert.SerializeObject(new AuthorizationModel {Activity = activity, UserEmail = userEmail}));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("authorize", content);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            if (response.StatusCode == HttpStatusCode.NoContent)
                return false;

            throw new AuthorizationException(response);
        }
    }
}