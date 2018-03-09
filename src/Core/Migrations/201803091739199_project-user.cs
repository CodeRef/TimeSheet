namespace TimeTracker.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shelves", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shelves", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shelves", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shops", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shops", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Shelves", new[] { "CreatedBy" });
            DropIndex("dbo.Shelves", new[] { "UpdatedBy" });
            DropIndex("dbo.Shelves", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Shops", new[] { "CreatedBy" });
            DropIndex("dbo.Shops", new[] { "UpdatedBy" });
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.ProjectId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ProjectId);
            
            DropTable("dbo.Shelves");
            DropTable("dbo.Shops");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ProjectUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectUsers", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectUsers", new[] { "ProjectId" });
            DropIndex("dbo.ProjectUsers", new[] { "ApplicationUserId" });
            DropTable("dbo.ProjectUsers");
            CreateIndex("dbo.Shops", "UpdatedBy");
            CreateIndex("dbo.Shops", "CreatedBy");
            CreateIndex("dbo.Shelves", "ApplicationUser_Id");
            CreateIndex("dbo.Shelves", "UpdatedBy");
            CreateIndex("dbo.Shelves", "CreatedBy");
            AddForeignKey("dbo.Shops", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Shops", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Shelves", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Shelves", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Shelves", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
