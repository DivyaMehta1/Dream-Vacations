namespace DreamVacations_CampBookingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "UserId_UserId", "dbo.Users");
            RenameColumn(table: "dbo.Bookings", name: "UserId_UserId", newName: "UserId_Id");
            RenameIndex(table: "dbo.Bookings", name: "IX_UserId_UserId", newName: "IX_UserId_Id");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.Bookings", "UserId_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserId", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.Bookings", "UserId_Id", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Id");
            AddPrimaryKey("dbo.Users", "UserId");
            RenameIndex(table: "dbo.Bookings", name: "IX_UserId_Id", newName: "IX_UserId_UserId");
            RenameColumn(table: "dbo.Bookings", name: "UserId_Id", newName: "UserId_UserId");
            AddForeignKey("dbo.Bookings", "UserId_UserId", "dbo.Users", "UserId");
        }
    }
}
