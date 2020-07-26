namespace NMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourite",
                c => new
                    {
                        favouriteId = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.favouriteId)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            DropColumn("dbo.Product", "isFavourite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "isFavourite", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Favourite", "userId", "dbo.User");
            DropForeignKey("dbo.Favourite", "productId", "dbo.Product");
            DropIndex("dbo.Favourite", new[] { "productId" });
            DropIndex("dbo.Favourite", new[] { "userId" });
            DropTable("dbo.Favourite");
        }
    }
}
