using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.Authorization.Api
{
    /// <summary>   An auhtorized for action handler. </summary>
    public class AuhtorizedForActionHandler : AuthorizationHandler<AuhtorizedForActionRequirement>
    {
        /// <summary>   The authorization service. </summary>
        private readonly AuthorizationService _authorizationService;

        /// <summary>   Constructor. </summary>
        /// <param name="authorizationService"> The authorization service. </param>
        public AuhtorizedForActionHandler(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        ///     Makes a decision if authorization is allowed based on a specific requirement.
        /// </summary>
        /// <param name="context">      The authorization context. </param>
        /// <param name="requirement">  The requirement to evaluate. </param>
        /// <returns>   An asynchronous result. </returns>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            AuhtorizedForActionRequirement requirement)
        {
            var email = context.User.Claims.SingleOrDefault(c => c.Type == "email")?.Value;
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (await _authorizationService.Activities.IsAuthorized(requirement.ActionName, email))
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
            else
            {
                context.Fail();
            }
        }
    }
}