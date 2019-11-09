using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data
{
    /// <summary>   Interface for authorization unit of work. </summary>
    public interface IAuthorizationUnitOfWork : IUnitOfWork
    {
        /// <summary>   Gets the action repository. </summary>
        /// <value> The action repository. </value>
        IActionRepository ActionRepository { get; }

        /// <summary>   Gets the role repository. </summary>
        /// <value> The role repository. </value>
        IRoleRepository RoleRepository { get; }

        /// <summary>   Gets the action role repository. </summary>
        /// <value> The action role repository. </value>
        IActionRoleRepository ActionRoleRepository { get; }
    }
}