using System;
using FluiTec.AppFx.Authorization.Data.LiteDb.Repositories;
using FluiTec.AppFx.Authorization.Data.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Data.LiteDb
{
    /// <summary>   A lite database authorization data service. </summary>
    public class LiteDbAuthorizationDataService : LiteDbDataService, IAuthorizationDataService
    {
        #region Properties

        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public override string Name => "LiteDbAuthorizationDataService";

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="useSingletonConnection">   True to use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbAuthorizationDataService(bool useSingletonConnection, string dbFilePath,
            string applicationFolder = null)
            : this(new LiteDbServiceOptions
            {
                UseSingletonConnection = useSingletonConnection,
                ApplicationFolder = applicationFolder,
                DbFileName = dbFilePath
            })
        {
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public LiteDbAuthorizationDataService(ILiteDbServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterRepositoryProviders();
        }

        #endregion

        #region Methods

        /// <summary>   Starts unit of work. </summary>
        /// <returns>   An IAuthorizationUnitOfWork. </returns>
        public IAuthorizationUnitOfWork StartUnitOfWork()
        {
            return new LiteDbAuthorizationUnitOfWork(this);
        }

        /// <summary>   Starts unit of work. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have
        ///     unsupported or illegal values.
        /// </exception>
        /// <param name="other">    The other. </param>
        /// <returns>   An IAuthorizationUnitOfWork. </returns>
        public IAuthorizationUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}");
            return new LiteDbAuthorizationUnitOfWork(this, (LiteDbUnitOfWork) other);
        }

        /// <summary>   Begins unit of work. </summary>
        /// <returns>   An IUnitOfWork. </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbAuthorizationUnitOfWork(this);
        }

        /// <summary>   Registers the repository providers. </summary>
        protected virtual void RegisterRepositoryProviders()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActionRepository>(work => new LiteDbActionRepository(work)));
            RegisterRepositoryProvider(new Func<IUnitOfWork, IRoleRepository>(work => new LiteDbRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActionRoleRepository>(work => new LiteDbActionRoleRepository(work)));
        }

        #endregion
    }
}