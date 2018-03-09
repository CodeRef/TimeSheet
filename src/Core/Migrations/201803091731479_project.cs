namespace TimeTracker.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        Feature_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Features", t => t.Feature_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.Feature_Id);
            
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "BirthDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Features", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Features", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskModels", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.TaskModels", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskModels", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Features", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.TaskModels", new[] { "Feature_Id" });
            DropIndex("dbo.TaskModels", new[] { "UpdatedBy" });
            DropIndex("dbo.TaskModels", new[] { "CreatedBy" });
            DropIndex("dbo.Features", new[] { "Project_Id" });
            DropIndex("dbo.Features", new[] { "UpdatedBy" });
            DropIndex("dbo.Features", new[] { "CreatedBy" });
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropTable("dbo.TaskModels");
            DropTable("dbo.Features");
        }
    }
}
