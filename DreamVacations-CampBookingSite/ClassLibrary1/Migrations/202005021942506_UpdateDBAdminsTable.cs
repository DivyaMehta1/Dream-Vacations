namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBAdminsTable : DbMigration
    {
        public override void Up()
        {
     
            RenameTable(name: "dbo.Users", newName: "Admins");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            AddColumn("dbo.Camps", "AdminId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Camps", "AdminId");
           // AddForeignKey("dbo.Camps", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
            DropColumn("dbo.Bookings", "UserId");
            DropColumn("dbo.Admins", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bookings", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Camps", "AdminId", "dbo.Admins");
            DropIndex("dbo.Camps", new[] { "AdminId" });
            DropColumn("dbo.Camps", "AdminId");
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Admins", newName: "Users");
        }
    }
}
