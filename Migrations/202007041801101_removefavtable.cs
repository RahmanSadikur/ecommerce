namespace NMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefavtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favourite", "productId", "dbo.Product");
            DropForeignKey("dbo.Favourite", "userId", "dbo.User");
            DropIndex("dbo.Favourite", new[] { "userId" });
            DropIndex("dbo.Favourite", new[] { "productId" });
            AddColumn("dbo.Product", "isPinnedProduct", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "isFavourite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "color", c => c.String());
            AddColumn("dbo.Image", "isPinned", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Category", "categoryName", c => c.String(nullable: false));
            AlterColumn("dbo.SubCategory", "subCategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "productName", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "productStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "contact", c => c.String(nullable: false));
            AlterColumn("dbo.User", "userName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.User", "address", c => c.String(nullable: false));
            AlterColumn("dbo.User", "designation", c => c.String(nullable: false));
            AlterColumn("dbo.userCridential", "userTypeName", c => c.String(nullable: false));
            AlterColumn("dbo.Image", "Productimage", c => c.Binary(nullable: false));
            AlterColumn("dbo.Company", "companyName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "companyAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "companyPhone", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "companyDescription", c => c.String(nullable: false));
            DropTable("dbo.Favourite");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Favourite",
                c => new
                    {
                        favouriteId = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.favouriteId);
            
            AlterColumn("dbo.Company", "companyDescription", c => c.String());
            AlterColumn("dbo.Company", "companyPhone", c => c.String());
            AlterColumn("dbo.Company", "companyAddress", c => c.String());
            AlterColumn("dbo.Company", "companyName", c => c.String());
            AlterColumn("dbo.Image", "Productimage", c => c.Binary());
            AlterColumn("dbo.userCridential", "userTypeName", c => c.String());
            AlterColumn("dbo.User", "designation", c => c.String());
            AlterColumn("dbo.User", "address", c => c.String());
            AlterColumn("dbo.User", "phone", c => c.String());
            AlterColumn("dbo.User", "userName", c => c.String());
            AlterColumn("dbo.Product", "contact", c => c.String());
            AlterColumn("dbo.Product", "productStatus", c => c.String());
            AlterColumn("dbo.Product", "productName", c => c.String());
            AlterColumn("dbo.SubCategory", "subCategoryName", c => c.String());
            AlterColumn("dbo.Category", "categoryName", c => c.String());
            DropColumn("dbo.Image", "isPinned");
            DropColumn("dbo.Product", "color");
            DropColumn("dbo.Product", "isFavourite");
            DropColumn("dbo.Product", "isPinnedProduct");
            CreateIndex("dbo.Favourite", "productId");
            CreateIndex("dbo.Favourite", "userId");
            AddForeignKey("dbo.Favourite", "userId", "dbo.User", "userId", cascadeDelete: true);
            AddForeignKey("dbo.Favourite", "productId", "dbo.Product", "productId", cascadeDelete: true);
        }
    }
}
