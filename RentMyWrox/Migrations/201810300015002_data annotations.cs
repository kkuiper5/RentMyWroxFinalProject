namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDemographics", "MaritalStatus", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDemographics", "MaritalStatus", c => c.String());
        }
    }
}
