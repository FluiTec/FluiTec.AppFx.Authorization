using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Migration.Versions.Migration1
{
    /// <summary>   An action table. </summary>
    [Migration(1)]
    public class ActionTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ActionTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ClientId").AsString().NotNullable()
                .WithColumn("Name").AsString(256).NotNullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ActionTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ClientId").AsString().NotNullable()
                .WithColumn("Name").AsString(256).NotNullable();
        }

        /// <summary>   Downs this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ActionTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ActionTable}");
        }
    }
}