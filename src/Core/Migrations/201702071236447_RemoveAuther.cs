using System.Data.Entity.Migrations;

namespace TimeTracker.Model.Migrations
{
    public partial class RemoveAuther : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Addresses",
                    c => new
                    {
                        Id = c.Int(false, true),
                        AddressText = c.String(),
                        ZipCode = c.String(),
                        CreatedDate = c.DateTime(false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(false),
                        UpdatedBy = c.String(maxLength: 128),
                        Country_Id = c.Int(),
                        State_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.States", t => t.State_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.Country_Id)
                .Index(t => t.State_Id);

            CreateTable(
                    "dbo.Countries",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        OIfficialName = c.String(),
                        IsoCode = c.String(),
                        IsoShort = c.String(),
                        IsoLong = c.String(),
                        UnCode = c.String(),
                        CapitalCity = c.String(),
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

            CreateTable(
                    "dbo.AspNetUsers",
                    c => new
                    {
                        Id = c.String(false, 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(false),
                        TwoFactorEnabled = c.Boolean(false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(false),
                        AccessFailedCount = c.Int(false),
                        UserName = c.String(false, 256)
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                    "dbo.AspNetUserClaims",
                    c => new
                    {
                        Id = c.Int(false, true),
                        UserId = c.String(false, 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.AspNetUserLogins",
                    c => new
                    {
                        LoginProvider = c.String(false, 128),
                        ProviderKey = c.String(false, 128),
                        UserId = c.String(false, 128)
                    })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.AspNetUserRoles",
                    c => new
                    {
                        UserId = c.String(false, 128),
                        RoleId = c.String(false, 128)
                    })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                    "dbo.Shelves",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(false),
                        UpdatedBy = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.ApplicationUser_Id);

            CreateTable(
                    "dbo.UserProfiles",
                    c => new
                    {
                        UserId = c.String(false, 128),
                        ApplicationUserId = c.String(false, 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(false),
                        Book_Id = c.Int()
                    })
                .PrimaryKey(t => new {t.UserId, t.ApplicationUserId})
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, true)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Book_Id);

            CreateTable(
                    "dbo.States",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(false),
                        UpdatedBy = c.String(maxLength: 128),
                        Country_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.Country_Id);

            CreateTable(
                    "dbo.Books",
                    c => new
                    {
                        Id = c.Int(false, true),
                        ISBN = c.String(),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        PublicationDate = c.DateTime(false),
                        Picture = c.String(),
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

            CreateTable(
                    "dbo.AspNetRoles",
                    c => new
                    {
                        Id = c.String(false, 128),
                        Name = c.String(false, 256)
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                    "dbo.ShelfBooks",
                    c => new
                    {
                        BookId = c.Int(false),
                        ShelfId = c.Int(false)
                    })
                .PrimaryKey(t => new {t.BookId, t.ShelfId})
                .ForeignKey("dbo.Books", t => t.BookId, true)
                .ForeignKey("dbo.Shelves", t => t.ShelfId, true)
                .Index(t => t.BookId)
                .Index(t => t.ShelfId);

            CreateTable(
                    "dbo.Shops",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(maxLength: 64),
                        IsActive = c.Boolean(false),
                        IsDeleted = c.Boolean(false),
                        IsPublished = c.Boolean(false),
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
            DropForeignKey("dbo.Shops", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shops", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShelfBooks", "ShelfId", "dbo.Shelves");
            DropForeignKey("dbo.ShelfBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Books", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProfiles", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Addresses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "State_Id", "dbo.States");
            DropForeignKey("dbo.Addresses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Countries", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.States", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProfiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shelves", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shelves", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shelves", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Shops", new[] {"UpdatedBy"});
            DropIndex("dbo.Shops", new[] {"CreatedBy"});
            DropIndex("dbo.ShelfBooks", new[] {"ShelfId"});
            DropIndex("dbo.ShelfBooks", new[] {"BookId"});
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Books", new[] {"UpdatedBy"});
            DropIndex("dbo.Books", new[] {"CreatedBy"});
            DropIndex("dbo.States", new[] {"Country_Id"});
            DropIndex("dbo.States", new[] {"UpdatedBy"});
            DropIndex("dbo.States", new[] {"CreatedBy"});
            DropIndex("dbo.UserProfiles", new[] {"Book_Id"});
            DropIndex("dbo.UserProfiles", new[] {"ApplicationUserId"});
            DropIndex("dbo.Shelves", new[] {"ApplicationUser_Id"});
            DropIndex("dbo.Shelves", new[] {"UpdatedBy"});
            DropIndex("dbo.Shelves", new[] {"CreatedBy"});
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.AspNetUserClaims", new[] {"UserId"});
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Countries", new[] {"UpdatedBy"});
            DropIndex("dbo.Countries", new[] {"CreatedBy"});
            DropIndex("dbo.Addresses", new[] {"State_Id"});
            DropIndex("dbo.Addresses", new[] {"Country_Id"});
            DropIndex("dbo.Addresses", new[] {"UpdatedBy"});
            DropIndex("dbo.Addresses", new[] {"CreatedBy"});
            DropTable("dbo.Shops");
            DropTable("dbo.ShelfBooks");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Books");
            DropTable("dbo.States");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Shelves");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}