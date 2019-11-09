using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data.Entities
{
    /// <summary>   A role entity. </summary>
    [EntityName("AppFxActionAuthorization.Role")]
    public class RoleEntity : IEntity<int>
    {
        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int Id { get; set; }
    }
}