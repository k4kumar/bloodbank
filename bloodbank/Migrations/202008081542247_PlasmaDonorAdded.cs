namespace bloodbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlasmaDonorAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlasmaDonors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AffectedDate = c.DateTime(nullable: false),
                        RecoveryDate = c.DateTime(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        HasDonated = c.Boolean(nullable: false),
                        BloodDonorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodDonors", t => t.BloodDonorId, cascadeDelete: true)
                .Index(t => t.BloodDonorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlasmaDonors", "BloodDonorId", "dbo.BloodDonors");
            DropIndex("dbo.PlasmaDonors", new[] { "BloodDonorId" });
            DropTable("dbo.PlasmaDonors");
        }
    }
}
