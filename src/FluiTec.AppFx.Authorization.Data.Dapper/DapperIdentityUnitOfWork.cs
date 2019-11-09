using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Data.Dapper
{
    /// <summary>   A dapper identity unit of work. </summary>
    public class DapperIdentityUnitOfWork : DapperUnitOfWork, IAuthorizationUnitOfWork
    {
        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="dataService">  The data service. </param>
        public DapperIdentityUnitOfWork(DapperDataService dataService) : base(dataService)
        {
        }

        /// <summary>   Constructor. </summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public DapperIdentityUnitOfWork(DapperDataService dataService, DapperUnitOfWork parentUnitOfWork) : base(
            dataService, parentUnitOfWork)
        {
        }

        #endregion

        #region Fields

        private IActionRepository _actionRepository;

        private IRoleRepository _roleRepository;

        private IActionRoleRepository _actionRoleRepository;

        #endregion

        #region IAuthorizationUnitOfWork

        /// <summary>   Gets the action repository. </summary>
        /// <value> The action repository. </value>
        public IActionRepository ActionRepository =>
            _actionRepository ?? (_actionRepository = GetRepository<IActionRepository>());

        /// <summary>   Gets the role repository. </summary>
        /// <value> The role repository. </value>
        public IRoleRepository RoleRepository =>
            _roleRepository ?? (_roleRepository = GetRepository<IRoleRepository>());

        /// <summary>   Gets the action role repository. </summary>
        /// <value> The action role repository. </value>
        public IActionRoleRepository ActionRoleRepository =>
            _actionRoleRepository ?? (_actionRoleRepository = GetRepository<IActionRoleRepository>());

        #endregion
    }
}