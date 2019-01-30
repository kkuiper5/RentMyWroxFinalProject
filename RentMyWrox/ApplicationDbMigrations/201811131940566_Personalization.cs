namespace RentMyWrox.ApplicationDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Personalization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address_Address1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address_Address2", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address_City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address_State", c => c.String(maxLength: 2));
            AddColumn("dbo.AspNetUsers", "Address_ZipCode", c => c.String(maxLength: 15));
            AddColumn("dbo.AspNetUsers", "UserDemographicsId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "OrderCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OrderCount");
            DropColumn("dbo.AspNetUsers", "UserDemographicsId");
            DropColumn("dbo.AspNetUsers", "Address_ZipCode");
            DropColumn("dbo.AspNetUsers", "Address_State");
            DropColumn("dbo.AspNetUsers", "Address_City");
            DropColumn("dbo.AspNetUsers", "Address_Address2");
            DropColumn("dbo.AspNetUsers", "Address_Address1");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
