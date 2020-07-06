namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactTypeUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Contact", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Contact", c => c.Int(nullable: false));
        }
    }
}
