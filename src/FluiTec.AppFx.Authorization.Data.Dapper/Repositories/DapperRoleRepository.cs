using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Repositories
{
    /// <summary>   A dapper role repository. </summary>
    public class DapperRoleRepository : DapperRepository<RoleEntity, int>, IRoleRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
