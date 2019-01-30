namespace RentMyWrox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDemographics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Birthdate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        DateMovedIntoArea = c.DateTime(nullable: false),
                        OwnHome = c.Boolean(nullable: false),
                        TotalPeopleInHome = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDemographicsHobbies",
                c => new
                    {
                        UserDemographics_Id = c.Int(nullable: false),
                        Hobby_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDemographics_Id, t.Hobby_Id })
                .ForeignKey("dbo.UserDemographics", t => t.UserDemographics_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hobbies", t => t.Hobby_Id, cascadeDelete: true)
                .Index(t => t.UserDemographics_Id)
                .Index(t => t.Hobby_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDemographicsHobbies", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.UserDemographicsHobbies", "UserDemographics_Id", "dbo.UserDemographics");
            DropIndex("dbo.UserDemographicsHobbies", new[] { "Hobby_Id" });
            DropIndex("dbo.UserDemographicsHobbies", new[] { "UserDemographics_Id" });
            DropTable("dbo.UserDemographicsHobbies");
            DropTable("dbo.UserDemographics");
            DropTable("dbo.Hobbies");
        }
    }
}
