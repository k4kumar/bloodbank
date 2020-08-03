namespace bloodbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BloodDonorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "BloodDonorId");
            AddForeignKey("dbo.Users", "BloodDonorId", "dbo.BloodDonors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BloodDonorId", "dbo.BloodDonors");
            DropIndex("dbo.Users", new[] { "BloodDonorId" });
            DropColumn("dbo.Users", "BloodDonorId");
        }
    }
}
