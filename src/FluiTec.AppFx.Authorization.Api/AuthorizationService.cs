using FluiTec.AppFx.Authorization.Api.Api;
using FluiTec.AppFx.Rest;
using Microsoft.Extensions.Caching.Memory;

namespace FluiTec.AppFx.Authorization.Api
{
    /// <summary>   An authorization service. </summary>
    public class AuthorizationService : BearerSecuredJsonService<AuthorizationServiceOptions>
    {
        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <param name="cache">    The cache. </param>
        public AuthorizationService(AuthorizationServiceOptions options, IMemoryCache cache) : base(options)
        {
            _cache = cache;
        }

        #endregion

        #region Fields

        /// <summary>   The activities. </summary>
        private AuthorizationActivitiesApi _activities;

        /// <summary>   The cache. </summary>
        private readonly IMemoryCache _cache;

        #endregion

        #region Methods

        /// <summary>   Validates the options described by options. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        protected override bool ValidateOptions(AuthorizationServiceOptions options)
        {
            return !string.IsNullOrWhiteSpace(options.ActivitiesPath) && base.ValidateOptions(options);
        }

        /// <summary>   Gets the activities. </summary>
        /// <value> The activities. </value>
        public AuthorizationActivitiesApi Activities =>
            _activities ?? (_activities = new AuthorizationActivitiesApi(this, Options.ActivitiesPath, _cache));

        #endregion
    }
}