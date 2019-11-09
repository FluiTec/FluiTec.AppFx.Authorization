using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Migration.Versions.Migration1
{
    /// <summary>   A role table. </summary>
    [Migration(2)]
    public class RoleTable : FluentMigrator.Migration
    {
        /// <summary>   Ups this object. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.RoleTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(256).NotNullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.RoleTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(256).NotNullable();
        }

        /// <summary>   Downs this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.RoleTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.RoleTable}");
        }
    }
}