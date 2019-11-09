using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Data.LiteDb.Repositories
{
    /// <summary>   A lite database role repository. </summary>
    public class LiteDbRoleRepository : LiteDbIntegerRepository<RoleEntity>, IRoleRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}