namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "CampId_Id", "dbo.Camps");
            DropForeignKey("dbo.Bookings", "UserId_Id", "dbo.Admins");
            DropIndex("dbo.Bookings", new[] { "CampId_Id" });
            DropIndex("dbo.Bookings", new[] { "UserId_Id" });
            RenameColumn(table: "dbo.Bookings", name: "CampId_Id", newName: "CampId");
            RenameColumn(table: "dbo.Bookings", name: "UserId_Id", newName: "UserId");
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "ReferenceNumber", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Bookings", "CampId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Bookings", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Bookings", "ReferenceNumber");
            CreateIndex("dbo.Bookings", "UserId");
            CreateIndex("dbo.Bookings", "CampId");
            AddForeignKey("dbo.Bookings", "CampId", "dbo.Camps", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Admins", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Admins");
            DropForeignKey("dbo.Bookings", "CampId", "dbo.Camps");
            DropIndex("dbo.Bookings", new[] { "CampId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "UserId", c => c.Guid());
            AlterColumn("dbo.Bookings", "CampId", c => c.Guid());
            AlterColumn("dbo.Bookings", "ReferenceNumber", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Bookings", "ReferenceNumber");
            RenameColumn(table: "dbo.Bookings", name: "UserId", newName: "UserId_Id");
            RenameColumn(table: "dbo.Bookings", name: "CampId", newName: "CampId_Id");
            CreateIndex("dbo.Bookings", "UserId_Id");
            CreateIndex("dbo.Bookings", "CampId_Id");
            AddForeignKey("dbo.Bookings", "UserId_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.Bookings", "CampId_Id", "dbo.Camps", "Id");
        }
    }
}
