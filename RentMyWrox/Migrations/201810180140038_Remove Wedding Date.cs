namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveWeddingDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserDemographics", "WeddingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDemographics", "WeddingDate", c => c.DateTime(nullable: false));
        }
    }
}
