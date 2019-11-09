using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data.Repositories
{
    /// <summary>   Interface for action repository. </summary>
    public interface IActionRepository : IDataRepository<ActionEntity, int>
    {
        /// <summary>   Gets the clients in this collection. </summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the clients in this collection.
        /// </returns>
        IEnumerable<ActionEntity> GetByClient(string clientId);
    }
}