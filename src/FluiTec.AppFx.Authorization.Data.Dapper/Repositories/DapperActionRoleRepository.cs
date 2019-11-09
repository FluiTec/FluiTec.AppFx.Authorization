using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Repositories
{
    /// <summary>   A dapper action role repository. </summary>
    public class DapperActionRoleRepository : DapperRepository<ActionRoleEntity, int>, IActionRoleRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperActionRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(ActionRoleEntity.ActionId));
            return UnitOfWork.Connection.Query<ActionRoleEntity>(command, new {ActionId = actionId},
                UnitOfWork.Transaction);
        }

        /// <summary>   Enumerates by role identifier in this collection. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by role identifier in this
        ///     collection.
        /// </returns>
        public IEnumerable<ActionRoleEntity> ByRoleId(int roleId)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(ActionRoleEntity.RoleId));
            return UnitOfWork.Connection.Query<ActionRoleEntity>(command, new {RoleId = roleId},
                UnitOfWork.Transaction);
        }
    }
}