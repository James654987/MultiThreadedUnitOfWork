using FluentMigrator;

namespace AsynchronousSessionManagement.Migrations
{
    [Migration(20234141555)]
    public class _20234141555_AddUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .InSchema("dbo")
                .WithColumn("PKey").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("User")
                .InSchema("dbo");
        }
    }
}