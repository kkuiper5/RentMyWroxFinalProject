namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regularpersonalization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ItemId = c.Int(nullable: false),
                        VisitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserVisits");
        }
    }
}
