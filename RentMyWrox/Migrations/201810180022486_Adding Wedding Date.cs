namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWeddingDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDemographics", "WeddingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDemographics", "WeddingDate");
        }
    }
}
