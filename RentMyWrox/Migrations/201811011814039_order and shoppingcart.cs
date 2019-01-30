namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderandshoppingcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        PickupDate = c.DateTime(nullable: false),
                        HowPaid = c.String(),
                        DiscountAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PricePaidEach = c.Double(nullable: false),
                        Item_Id = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Item_Id", "dbo.Items");
            DropIndex("dbo.ShoppingCarts", new[] { "Item_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Item_Id" });
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
    }
}
