using FluiTec.AppFx.Authorization.Data.Entities;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data.Repositories
{
    /// <summary>   Interface for role repository. </summary>
    public interface IRoleRepository : IDataRepository<RoleEntity, int>
    {
    }
}