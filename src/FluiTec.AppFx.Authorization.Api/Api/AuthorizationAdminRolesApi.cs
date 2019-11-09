using System;
using System.Threading.Tasks;
using FluiTec.AppFx.Authorization.Models;
using FluiTec.AppFx.Rest;

namespace FluiTec.AppFx.Authorization.Api.Api
{
    /// <summary>   An authorization admin roles api. </summary>
    public class AuthorizationAdminRolesApi : DefaultJsonApi<RoleModel>
    {
        /// <summary>   Constructor. </summary>
        /// <param name="service">  The service. </param>
        /// <param name="subPath">  Full pathname of the sub file. </param>
        public AuthorizationAdminRolesApi(IWebService service, string subPath) : base(service, subPath)
        {
        }

        /// <summary>   Deletes the given model. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="model">    The model to delete. </param>
        /// <returns>   An asynchronous result. </returns>
        public override async Task Delete(RoleModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            await Delete(model.Id);
        }
    }
}