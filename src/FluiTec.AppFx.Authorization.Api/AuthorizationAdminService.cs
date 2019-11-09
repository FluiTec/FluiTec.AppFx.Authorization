using FluiTec.AppFx.Authorization.Api.Api;
using FluiTec.AppFx.Rest;

namespace FluiTec.AppFx.Authorization.Api
{
    /// <summary>   An authorization admin service. </summary>
    public class AuthorizationAdminService : BearerSecuredJsonService<AuthorizationServiceOptions>
    {
        #region Fields

        private AuthorizationAdminActivitiesApi _activities;

        private AuthorizationAdminRolesApi _roles;

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public AuthorizationAdminService(AuthorizationServiceOptions options) : base(options)
        {
        }

        #endregion

        #region Methods

        /// <summary>   Validates the options described by options. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        protected override bool ValidateOptions(AuthorizationServiceOptions options)
        {
            return !string.IsNullOrWhiteSpace(options.AdminActivitiesPath) && !string.IsNullOrWhiteSpace(options.RolesPath) && base.ValidateOptions(options);
        }

        #endregion

        #region Api

        /// <summary>   Gets the activities. </summary>
        /// <value> The activities. </value>
        public AuthorizationAdminActivitiesApi Activities => _activities ?? (_activities = new AuthorizationAdminActivitiesApi(this, Options.AdminActivitiesPath));

        /// <summary>   Gets the roles. </summary>
        /// <value> The roles. </value>
        public AuthorizationAdminRolesApi Roles =>
            _roles ?? (_roles = new AuthorizationAdminRolesApi(this, Options.RolesPath));

        #endregion
    }
}