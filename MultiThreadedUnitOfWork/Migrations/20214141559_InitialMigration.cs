using FluentMigrator;

namespace AsynchronousSessionManagement.Migrations
{
    [Migration(20214141559)]
    public class _20214141559_InitialMigration : Migration
    {
        public override void Up()
        {
            //Create.Schema("dbo");
        }

        public override void Down()
        {
            Delete.Schema("dbo");
        }
    }
}