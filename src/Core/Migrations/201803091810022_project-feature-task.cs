namespace TimeTracker.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectfeaturetask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prospects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            AddColumn("dbo.Addresses", "Prospect_Id", c => c.Int());
            AddColumn("dbo.ProjectUsers", "StartDate", c => c.DateTime());
            AddColumn("dbo.ProjectUsers", "EndDate", c => c.DateTime());
            CreateIndex("dbo.Addresses", "Prospect_Id");
            AddForeignKey("dbo.Addresses", "Prospect_Id", "dbo.Prospects", "Id");
            DropColumn("dbo.TaskModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Prospects", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Prospects", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "Prospect_Id", "dbo.Prospects");
            DropIndex("dbo.Prospects", new[] { "UpdatedBy" });
            DropIndex("dbo.Prospects", new[] { "CreatedBy" });
            DropIndex("dbo.Addresses", new[] { "Prospect_Id" });
            DropColumn("dbo.ProjectUsers", "EndDate");
            DropColumn("dbo.ProjectUsers", "StartDate");
            DropColumn("dbo.Addresses", "Prospect_Id");
            DropTable("dbo.Prospects");
        }
    }
}
