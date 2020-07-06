namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatatype : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "ReferenceNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Bookings", "ReferenceNumber");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "ReferenceNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Bookings", "ReferenceNumber");
        }
    }
}
