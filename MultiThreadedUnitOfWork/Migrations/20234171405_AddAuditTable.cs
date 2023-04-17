using FluentMigrator;

namespace AsynchronousSessionManagement.Migrations
{
    [Migration(20234171405)]
    public class _20234171405_AddAuditTable : Migration
    {
        public override void Up()
        {
            Create.Table("Audit")
                .InSchema("dbo")
                .WithColumn("PKey").AsInt32().PrimaryKey().Identity()
                .WithColumn("TableModified").AsString(50).NotNullable()
                .WithColumn("DateTimeUpdated").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Audit")
                .InSchema("dbo");
        }
    }
}