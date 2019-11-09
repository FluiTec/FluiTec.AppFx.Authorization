using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Migration.Versions.Migration2
{
    /// <summary>   An action table. </summary>
    [Migration(4)]
    public class ActionTable : FluentMigrator.Migration
    {
        private const string ConstraintName = "UX_Action_Name";

        /// <summary>   Ups this object. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .UniqueConstraint(ConstraintName)
                .OnTable(Globals.ActionTable)
                .WithSchema(Globals.Schema)
                .Column("Name");

            IfDatabase("mysql")
                .Create
                .UniqueConstraint("UX_Action_Name")
                .OnTable($"{Globals.Schema}_{Globals.ActionTable}")
                .Column("Name");
        }

        /// <summary>   Downs this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .UniqueConstraint(ConstraintName)
                .FromTable(Globals.ActionTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .UniqueConstraint(ConstraintName)
                .FromTable($"{Globals.Schema}_{Globals.ActionTable}");
        }
    }
}
