using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Data.LiteDb.Repositories
{
    /// <summary>   A lite database action repository. </summary>
    public class LiteDbActionRepository : LiteDbIntegerRepository<ActionEntity>, IActionRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbActionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>   Gets the clients in this collection. </summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the clients in this collection.
        /// </returns>
        public IEnumerable<ActionEntity> GetByClient(string clientId)
        {
            return Collection.Find(e => e.ClientId == clientId);
        }
    }
}
