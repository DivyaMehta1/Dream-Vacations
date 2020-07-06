namespace DreamVacations_CampBookingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "UserId_UserId", "dbo.Admins");
            RenameColumn(table: "dbo.Bookings", name: "UserId_UserId", newName: "UserId_Id");
            RenameIndex(table: "dbo.Bookings", name: "IX_UserId_UserId", newName: "IX_UserId_Id");
            DropPrimaryKey("dbo.Admins");
            AddColumn("dbo.Admins", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Admins", "Id");
            AddForeignKey("dbo.Bookings", "UserId_Id", "dbo.Admins", "Id");
            DropColumn("dbo.Admins", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "UserId", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.Bookings", "UserId_Id", "dbo.Admins");
            DropPrimaryKey("dbo.Admins");
            DropColumn("dbo.Admins", "Id");
            AddPrimaryKey("dbo.Admins", "UserId");
            RenameIndex(table: "dbo.Bookings", name: "IX_UserId_Id", newName: "IX_UserId_UserId");
            RenameColumn(table: "dbo.Bookings", name: "UserId_Id", newName: "UserId_UserId");
            AddForeignKey("dbo.Bookings", "UserId_UserId", "dbo.Admins", "UserId");
        }
    }
}
