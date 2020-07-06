namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ReferenceNumber = c.Guid(nullable: false, identity: true),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        TotalNights = c.Int(nullable: false),
                        BillingAddress = c.String(),
                        Contact = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        NoOfPeople = c.Int(nullable: false),
                        CampId_Id = c.Guid(),
                        UserId_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ReferenceNumber)
                .ForeignKey("dbo.Camps", t => t.CampId_Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.CampId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Camps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Capacity = c.Int(nullable: false),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        IsBooked = c.Boolean(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Bookings", "CampId_Id", "dbo.Camps");
            DropIndex("dbo.Bookings", new[] { "UserId_Id" });
            DropIndex("dbo.Bookings", new[] { "CampId_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Camps");
            DropTable("dbo.Bookings");
        }
    }
}
