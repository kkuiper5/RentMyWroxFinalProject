namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Details = c.String(maxLength: 750),
                        IsAdminOnly = c.Boolean(nullable: false),
                        DisplayStartDate = c.DateTime(nullable: false),
                        DisplayEndDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
