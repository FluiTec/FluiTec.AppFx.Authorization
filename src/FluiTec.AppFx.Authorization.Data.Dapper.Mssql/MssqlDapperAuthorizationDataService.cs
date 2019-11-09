using System;
using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.Authorization.Data.Dapper.Migration;
using FluiTec.AppFx.Authorization.Data.Dapper.Repositories;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Mssql
{
    /// <summary>   A mssql dapper authorization data service. </summary>
    public class MssqlDapperAuthorizationDataService : MssqlDapperDataService, IAuthorizationDataService
    {
        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public MssqlDapperAuthorizationDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region IAuthorizationDataService

        /// <summary>   Starts unit of work. </summary>
        /// <returns>   An IAuthorizationUnitOfWork. </returns>
        public IAuthorizationUnitOfWork StartUnitOfWork()
        {
            return new DapperIdentityUnitOfWork(this);
        }

        /// <summary>   Starts unit of work. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="other">    The other. </param>
        /// <returns>   An IAuthorizationUnitOfWork. </returns>
        public IAuthorizationUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}");
            return new DapperIdentityUnitOfWork(this, (DapperUnitOfWork)other);
        }

        #endregion

        #region Properties

        /// <summary>	The name. </summary>
        public override string Name => "MssqlDapperAuthorizationDataService";

        /// <summary>   Gets information describing the meta. </summary>
        /// <value> Information describing the meta. </value>
        public override IVersionTableMetaData MetaData => new VersionTable();

        #endregion

        #region Methods

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActionRepository>(work => new DapperActionRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IRoleRepository>(work => new DapperRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActionRoleRepository>(work => new DapperActionRoleRepository(work)));
        }

        #endregion
    }
}