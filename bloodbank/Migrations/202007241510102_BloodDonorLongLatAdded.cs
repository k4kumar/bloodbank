namespace bloodbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodDonorLongLatAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BloodDonors", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.BloodDonors", "Latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BloodDonors", "Latitude");
            DropColumn("dbo.BloodDonors", "Longitude");
        }
    }
}
