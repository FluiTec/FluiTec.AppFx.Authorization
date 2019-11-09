using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.Authorization.Api
{
    /// <summary>   An auhtorized for action requirement. </summary>
    public class AuhtorizedForActionRequirement : IAuthorizationRequirement
    {
        /// <summary>   Gets the name of the action. </summary>
        /// <value> The name of the action. </value>
        public string ActionName { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="actionName">   The name of the action. </param>
        public AuhtorizedForActionRequirement(string actionName)
        {
            ActionName = actionName;
        }
    }
}
