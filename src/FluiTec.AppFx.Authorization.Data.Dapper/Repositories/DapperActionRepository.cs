using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Repositories
{
    /// <summary>   A dapper action repository. </summary>
    public class DapperActionRepository : DapperRepository<ActionEntity, int>, IActionRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperActionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region IActionRepository

        /// <summary>   Gets the clients in this collection. </summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the clients in this collection.
        /// </returns>
        public IEnumerable<ActionEntity> GetByClient(string clientId)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(ActionEntity.ClientId));
            return UnitOfWork.Connection.Query<ActionEntity>(command, new {ClientId = clientId},
                UnitOfWork.Transaction);
        }

        #endregion
    }
}