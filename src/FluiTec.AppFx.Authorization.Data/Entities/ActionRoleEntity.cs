using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data.Entities
{
    /// <summary>   An action role entity. </summary>
    [EntityName("AppFxActionAuthorization.ActionRole")]
    public class ActionRoleEntity : IEntity<int>
    {
        /// <summary>   Gets or sets the identifier of the action. </summary>
        /// <value> The identifier of the action. </value>
        public int ActionId { get; set; }

        /// <summary>   Gets or sets the identifier of the role. </summary>
        /// <value> The identifier of the role. </value>
        public int RoleId { get; set; }

        /// <summary>   Gets or sets the allow. </summary>
        /// <value> The allow. </value>
        public bool? Allow { get; set; }

        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int Id { get; set; }
    }
}