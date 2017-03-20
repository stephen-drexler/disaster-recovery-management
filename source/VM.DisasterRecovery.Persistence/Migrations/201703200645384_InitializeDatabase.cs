namespace VM.DisasterRecovery.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DisasterId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disasters", t => t.DisasterId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DisasterId);
            
            CreateTable(
                "dbo.Disasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Summary = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Location = c.String(),
                        SmallImageUrl = c.String(maxLength: 2000),
                        LargeImageUrl = c.String(maxLength: 2000),
                        AlternateImageText = c.String(maxLength: 255),
                        EstimatedExpense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        SupplyId = c.Int(nullable: false),
                        DisasterId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Disasters", t => t.DisasterId)
                .Index(t => t.UserId)
                .Index(t => t.SupplyId)
                .Index(t => t.DisasterId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VolunteerJobs",
                c => new
                    {
                        DisasterId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        Positions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DisasterId, t.JobId })
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Disasters", t => t.DisasterId)
                .Index(t => t.DisasterId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonateSupplies",
                c => new
                    {
                        DisasterId = c.Int(nullable: false),
                        SupplyId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Disaster_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DisasterId, t.SupplyId })
                .ForeignKey("dbo.Disasters", t => t.DisasterId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .ForeignKey("dbo.Disasters", t => t.Disaster_Id)
                .Index(t => t.DisasterId)
                .Index(t => t.SupplyId)
                .Index(t => t.Disaster_Id);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        JobId = c.Int(nullable: false),
                        DisasterId = c.Int(nullable: false),
                        Disaster_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disasters", t => t.DisasterId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Disasters", t => t.Disaster_Id)
                .Index(t => t.UserId)
                .Index(t => t.JobId)
                .Index(t => t.DisasterId)
                .Index(t => t.Disaster_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Contributions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Volunteers", "Disaster_Id", "dbo.Disasters");
            DropForeignKey("dbo.Volunteers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Volunteers", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Volunteers", "DisasterId", "dbo.Disasters");
            DropForeignKey("dbo.DonateSupplies", "Disaster_Id", "dbo.Disasters");
            DropForeignKey("dbo.DonateSupplies", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.DonateSupplies", "DisasterId", "dbo.Disasters");
            DropForeignKey("dbo.VolunteerJobs", "DisasterId", "dbo.Disasters");
            DropForeignKey("dbo.VolunteerJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Donations", "DisasterId", "dbo.Disasters");
            DropForeignKey("dbo.Donations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.Contributions", "DisasterId", "dbo.Disasters");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Volunteers", new[] { "Disaster_Id" });
            DropIndex("dbo.Volunteers", new[] { "DisasterId" });
            DropIndex("dbo.Volunteers", new[] { "JobId" });
            DropIndex("dbo.Volunteers", new[] { "UserId" });
            DropIndex("dbo.DonateSupplies", new[] { "Disaster_Id" });
            DropIndex("dbo.DonateSupplies", new[] { "SupplyId" });
            DropIndex("dbo.DonateSupplies", new[] { "DisasterId" });
            DropIndex("dbo.VolunteerJobs", new[] { "JobId" });
            DropIndex("dbo.VolunteerJobs", new[] { "DisasterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Donations", new[] { "DisasterId" });
            DropIndex("dbo.Donations", new[] { "SupplyId" });
            DropIndex("dbo.Donations", new[] { "UserId" });
            DropIndex("dbo.Contributions", new[] { "DisasterId" });
            DropIndex("dbo.Contributions", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Volunteers");
            DropTable("dbo.DonateSupplies");
            DropTable("dbo.Jobs");
            DropTable("dbo.VolunteerJobs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Supplies");
            DropTable("dbo.Donations");
            DropTable("dbo.Disasters");
            DropTable("dbo.Contributions");
        }
    }
}
