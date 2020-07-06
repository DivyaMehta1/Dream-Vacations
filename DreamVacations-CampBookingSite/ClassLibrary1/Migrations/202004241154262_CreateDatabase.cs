namespace DreamVacations_CampBookingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ReferenceNumber = c.Guid(nullable: false, identity: true),
                        TotalNights = c.Int(nullable: false),
                        BillingAddress = c.String(),
                        Contact = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        NoOfPeople = c.Int(nullable: false),
                        CampId_Id = c.Guid(),
                        UserId_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.ReferenceNumber)
                .ForeignKey("dbo.Camps", t => t.CampId_Id)
                .ForeignKey("dbo.Admins", t => t.UserId_UserId)
                .Index(t => t.CampId_Id)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Camps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                        Title = c.String(),
                        IsBooked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId_UserId", "dbo.Admins");
            DropForeignKey("dbo.Bookings", "CampId_Id", "dbo.Camps");
            DropIndex("dbo.Bookings", new[] { "UserId_UserId" });
            DropIndex("dbo.Bookings", new[] { "CampId_Id" });
            DropTable("dbo.Admins");
            DropTable("dbo.Camps");
            DropTable("dbo.Bookings");
        }
    }
}
