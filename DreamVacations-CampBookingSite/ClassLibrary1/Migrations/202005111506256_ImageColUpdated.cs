namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageColUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Camps", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Camps", "Image", c => c.Binary());
        }
    }
}
