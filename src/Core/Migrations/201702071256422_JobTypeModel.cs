using System.Data.Entity.Migrations;

namespace TimeTracker.Model.Migrations
{
    public partial class JobTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.JobTypes",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(false),
                        UpdatedBy = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
        }

        public override void Down()
        {
            DropForeignKey("dbo.JobTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobTypes", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.JobTypes", new[] {"UpdatedBy"});
            DropIndex("dbo.JobTypes", new[] {"CreatedBy"});
            DropTable("dbo.JobTypes");
        }
    }
}