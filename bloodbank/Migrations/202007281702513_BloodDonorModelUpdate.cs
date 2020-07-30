namespace bloodbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodDonorModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BloodDonors", "RegNo", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.BloodDonors", "NickName", c => c.String(maxLength: 100));
            AddColumn("dbo.BloodDonors", "Division", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.BloodDonors", "EmergencyContact", c => c.String(nullable: false, maxLength: 13));
            AddColumn("dbo.BloodDonors", "Comment", c => c.String(maxLength: 500));
            AlterColumn("dbo.BloodDonors", "Email", c => c.String(maxLength: 100));
            DropColumn("dbo.BloodDonors", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BloodDonors", "Address", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.BloodDonors", "Email", c => c.String());
            DropColumn("dbo.BloodDonors", "Comment");
            DropColumn("dbo.BloodDonors", "EmergencyContact");
            DropColumn("dbo.BloodDonors", "Division");
            DropColumn("dbo.BloodDonors", "NickName");
            DropColumn("dbo.BloodDonors", "RegNo");
        }
    }
}
