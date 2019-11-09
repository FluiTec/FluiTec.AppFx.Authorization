using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Data.Entities
{
    /// <summary>   An action entity. </summary>
    [EntityName("AppFxActionAuthorization.Action")]
    public class ActionEntity : IEntity<int>
    {
        /// <summary>   Gets or sets the identifier of the client. </summary>
        /// <value> The identifier of the client. </value>
        public string ClientId { get; set; }

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int Id { get; set; }
    }
}