namespace NMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordfixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "password");
        }
    }
}
