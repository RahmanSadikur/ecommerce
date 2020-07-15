namespace NMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "ImageTitle", c => c.String(nullable: false));
            AddColumn("dbo.Image", "ImageData", c => c.Binary(nullable: false));
            DropColumn("dbo.Image", "Productimage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Image", "Productimage", c => c.Binary(nullable: false));
            DropColumn("dbo.Image", "ImageData");
            DropColumn("dbo.Image", "ImageTitle");
        }
    }
}
