namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingFunctionality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Camps", "Rating", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Bookings", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Rating", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Camps", "Rating");
        }
    }
}
