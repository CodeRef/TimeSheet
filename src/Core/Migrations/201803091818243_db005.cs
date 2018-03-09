namespace TimeTracker.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db005 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeatureUsers",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        FeatureId = c.Guid(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.FeatureId })
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.FeatureId);
            
            CreateTable(
                "dbo.TaskUsers",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        TaskModelId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.TaskModelId })
                .ForeignKey("dbo.TaskModels", t => t.TaskModelId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.TaskModelId);
            
            CreateTable(
                "dbo.TimeLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        TaskUser_ApplicationUserId = c.String(maxLength: 128),
                        TaskUser_TaskModelId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskUsers", t => new { t.TaskUser_ApplicationUserId, t.TaskUser_TaskModelId })
                .Index(t => new { t.TaskUser_ApplicationUserId, t.TaskUser_TaskModelId });
            
            AddColumn("dbo.Projects", "Prospect_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Prospect_Id");
            AddForeignKey("dbo.Projects", "Prospect_Id", "dbo.Prospects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TimeLogs", new[] { "TaskUser_ApplicationUserId", "TaskUser_TaskModelId" }, "dbo.TaskUsers");
            DropForeignKey("dbo.TaskUsers", "TaskModelId", "dbo.TaskModels");
            DropForeignKey("dbo.Projects", "Prospect_Id", "dbo.Prospects");
            DropForeignKey("dbo.FeatureUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FeatureUsers", "FeatureId", "dbo.Features");
            DropIndex("dbo.TimeLogs", new[] { "TaskUser_ApplicationUserId", "TaskUser_TaskModelId" });
            DropIndex("dbo.TaskUsers", new[] { "TaskModelId" });
            DropIndex("dbo.TaskUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Projects", new[] { "Prospect_Id" });
            DropIndex("dbo.FeatureUsers", new[] { "FeatureId" });
            DropIndex("dbo.FeatureUsers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Projects", "Prospect_Id");
            DropTable("dbo.TimeLogs");
            DropTable("dbo.TaskUsers");
            DropTable("dbo.FeatureUsers");
        }
    }
}
