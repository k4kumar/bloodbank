namespace bloodbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodDonors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 500),
                        Mobile = c.String(nullable: false, maxLength: 13),
                        LastDonatedDate = c.DateTime(),
                        BloodGroup = c.String(nullable: false),
                        Email = c.String(),
                        HasDonated = c.Boolean(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Hospitals");
            DropTable("dbo.BloodDonors");
        }
    }
}
