using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Data.LiteDb.Repositories
{
    /// <summary>   A lite database action role repository. </summary>
    public class LiteDbActionRoleRepository : LiteDbIntegerRepository<ActionRoleEntity>, IActionRoleRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbActionRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>   Enumerates by action identifier in this collection. </summary>
        /// <param name="actionId"> Identifier for the action. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by action identifier in this
        ///     collection.
        /// </returns>
        public IEnumerable<ActionRoleEntity> ByActionId(int actionId)
        {
            return Collection.Find(e => e.ActionId == actionId);
        }

        /// <summary>   Enumerates by role identifier in this collection. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by role identifier in this
        ///     collection.
        /// </returns>
        public IEnumerable<ActionRoleEntity> ByRoleId(int roleId)
        {
            return Collection.Find(e => e.RoleId == roleId);
        }
    }
}