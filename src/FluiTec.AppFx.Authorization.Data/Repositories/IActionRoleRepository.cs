using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data.Repositories
{
    /// <summary>   Interface for action role repository. </summary>
    public interface IActionRoleRepository : IDataRepository<ActionRoleEntity, int>
    {
        /// <summary>   Enumerates by action identifier in this collection. </summary>
        /// <param name="actionId"> Identifier for the action. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by action identifier in this
        ///     collection.
        /// </returns>
        IEnumerable<ActionRoleEntity> ByActionId(int actionId);

        /// <summary>   Enumerates by role identifier in this collection. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by role identifier in this
        ///     collection.
        /// </returns>
        IEnumerable<ActionRoleEntity> ByRoleId(int roleId);
    }
}