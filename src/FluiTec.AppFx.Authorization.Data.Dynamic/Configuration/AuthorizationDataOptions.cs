using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Authorization.Data.Dynamic.Configuration
{
    /// <summary>   An authorization data options. </summary>
    [ConfigurationName("AuthorizationDataOptions")]
    public class AuthorizationDataOptions
    {
        /// <summary>	Gets or sets the provider. </summary>
        /// <value>	The provider. </value>
        /// <remarks>
        ///     Possible values:
        ///     - MSSQL
        ///     - PGSQL
        ///     - MYSQL
        ///     - LITEDB
        ///     <see cref="DataProvider" />
        /// </remarks>
        public DataProvider Provider { get; set; }
    }
}