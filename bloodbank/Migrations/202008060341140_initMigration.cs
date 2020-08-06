namespace bloodbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodDonors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        NickName = c.String(maxLength: 100),
                        Division = c.String(nullable: false, maxLength: 500),
                        Mobile = c.String(nullable: false, maxLength: 13),
                        EmergencyContact = c.String(nullable: false, maxLength: 13),
                        LastDonatedDate = c.DateTime(),
                        BloodGroup = c.String(nullable: false),
                        Email = c.String(maxLength: 100),
                        Comment = c.String(maxLength: 500),
                        HasDonated = c.Boolean(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonationPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishDate = c.DateTime(nullable: false),
                        Location = c.String(maxLength: 255),
                        Hospital = c.String(maxLength: 255),
                        Contact = c.String(maxLength: 100),
                        BloodGroup = c.String(maxLength: 10),
                        Details = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserRole = c.String(maxLength: 70),
                        Email = c.String(maxLength: 100),
                        PasswordSalt = c.String(maxLength: 150),
                        Password = c.String(maxLength: 255),
                        UserName = c.String(maxLength: 100),
                        FullName = c.String(maxLength: 150),
                        MobileNumber = c.String(maxLength: 30),
                        Image = c.String(maxLength: 255),
                        Token = c.String(maxLength: 255),
                        ForgetPasswordToken = c.String(maxLength: 255),
                        SecuritySitemap = c.String(maxLength: 255),
                        FailedLoginAttempt = c.Int(nullable: false),
                        BlockedUser = c.Boolean(nullable: false),
                        LastLoginAt = c.DateTime(),
                        BloodDonorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.BloodDonors", t => t.BloodDonorId, cascadeDelete: true)
                .Index(t => t.BloodDonorId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Address = c.String(nullable: false, maxLength: 500),
                        Type = c.String(),
                        Contact = c.String(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonationPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "BloodDonorId", "dbo.BloodDonors");
            DropIndex("dbo.Users", new[] { "BloodDonorId" });
            DropIndex("dbo.DonationPosts", new[] { "UserId" });
            DropTable("dbo.Hospitals");
            DropTable("dbo.Users");
            DropTable("dbo.DonationPosts");
            DropTable("dbo.BloodDonors");
        }
    }
}
