using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Migration.Versions.Migration1
{
    /// <summary>   An action role table. </summary>
    [Migration(3)]
    public class ActionRoleTable : FluentMigrator.Migration
    {
        /// <summary>   Ups this object. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ActionRoleTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ActionId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("Allow").AsBoolean().Nullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ActionRoleTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ActionId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("Allow").AsBoolean().Nullable();
        }

        /// <summary>   Downs this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ActionRoleTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ActionRoleTable}");
        }
    }
}
