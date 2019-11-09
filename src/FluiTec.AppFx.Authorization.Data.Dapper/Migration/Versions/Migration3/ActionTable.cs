using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Data.Dapper.Migration.Versions.Migration3
{
    /// <summary>   An action table. </summary>
    [Migration(5)]
    public class ActionTable : FluentMigrator.Migration
    {
        private const string ConstraintName = "UX_Action_Name";

        /// <summary>   Ups this object. </summary>
        public override void Up()
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

            IfDatabase("sqlserver", "postgres")
                .Create
                .UniqueConstraint(ConstraintName)
                .OnTable(Globals.ActionTable)
                .WithSchema(Globals.Schema)
                .Columns("ClientId", "Name");

            IfDatabase("mysql")
                .Create
                .UniqueConstraint("UX_Action_Name")
                .OnTable($"{Globals.Schema}_{Globals.ActionTable}")
                .Columns("ClientId", "Name");
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
    }
}
