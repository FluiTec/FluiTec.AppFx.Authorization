using System.Collections.Generic;
using FluiTec.AppFx.Rest;

namespace FluiTec.AppFx.Authorization.Api
{
    /// <summary>   An authorization service options. </summary>
    public class AuthorizationServiceOptions : BearerSecuredServiceOptions
    {
        private string _activitiesPath;

        private string _adminActivitiesPath;

        private string _rolesPath;

        /// <summary>   Default constructor. </summary>
        public AuthorizationServiceOptions()
        {
            ActivitiesPath = "/api/authorization/activities";
            AdminActivitiesPath = "/api/authorization/adminactivities";
            RolesPath = "/api/authorization/roles";

            SynchronizeActivities = false;
            Activities = new List<string>();
        }

        /// <summary>   Gets or sets the full pathname of the activities file. </summary>
        /// <value> The full pathname of the activities file. </value>
        public string ActivitiesPath
        {
            get => _activitiesPath;
            set
            {
                if (value != null && !value.EndsWith("/"))
                    value = string.Concat(value, "/");
                _activitiesPath = value;
            }
        }

        /// <summary>   Gets or sets the full pathname of the admin activities file. </summary>
        /// <value> The full pathname of the admin activities file. </value>
        public string AdminActivitiesPath
        {
            get => _adminActivitiesPath;
            set
            {
                if (value != null && !value.EndsWith("/"))
                    value = string.Concat(value, "/");
                _adminActivitiesPath = value;
            }
        }

        /// <summary>   Gets or sets the full pathname of the roles file. </summary>
        /// <value> The full pathname of the roles file. </value>
        public string RolesPath
        {
            get => _rolesPath;
            set
            {
                if (value != null && !value.EndsWith("/"))
                    value = string.Concat(value, "/");
                _rolesPath = value;
            }
        }

        /// <summary>   Gets or sets a value indicating whether the synchronize activities. </summary>
        /// <value> True if synchronize activities, false if not. </value>
        public bool SynchronizeActivities { get; set; }

        /// <summary>   Gets or sets the activities. </summary>
        /// <value> The activities. </value>
        public List<string> Activities { get; set; }
    }
}