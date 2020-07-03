namespace NMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        subCategoryId = c.Int(nullable: false, identity: true),
                        subCategoryName = c.String(),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.subCategoryId)
                .ForeignKey("dbo.Category", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        productDescription = c.String(),
                        productPrice = c.Double(nullable: false),
                        productStatus = c.String(),
                        contact = c.String(),
                        subCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.SubCategory", t => t.subCategoryId, cascadeDelete: true)
                .Index(t => t.subCategoryId);
            
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
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        email = c.String(),
                        phone = c.String(),
                        address = c.String(),
                        designation = c.String(),
                        description = c.String(),
                        userTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId)
                .ForeignKey("dbo.userCridential", t => t.userTypeId, cascadeDelete: true)
                .Index(t => t.userTypeId);
            
            CreateTable(
                "dbo.userCridential",
                c => new
                    {
                        userTypeId = c.Int(nullable: false, identity: true),
                        userTypeName = c.String(),
                    })
                .PrimaryKey(t => t.userTypeId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        imageId = c.Int(nullable: false, identity: true),
                        Productimage = c.Binary(),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.imageId)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        companyID = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                        companyAddress = c.String(),
                        companyLogo = c.Binary(),
                        companyPhone = c.String(),
                        companyEmail = c.String(),
                        companyDescription = c.String(),
                    })
                .PrimaryKey(t => t.companyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "subCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.Image", "productId", "dbo.Product");
            DropForeignKey("dbo.User", "userTypeId", "dbo.userCridential");
            DropForeignKey("dbo.Favourite", "userId", "dbo.User");
            DropForeignKey("dbo.Favourite", "productId", "dbo.Product");
            DropForeignKey("dbo.SubCategory", "categoryId", "dbo.Category");
            DropIndex("dbo.Image", new[] { "productId" });
            DropIndex("dbo.User", new[] { "userTypeId" });
            DropIndex("dbo.Favourite", new[] { "productId" });
            DropIndex("dbo.Favourite", new[] { "userId" });
            DropIndex("dbo.Product", new[] { "subCategoryId" });
            DropIndex("dbo.SubCategory", new[] { "categoryId" });
            DropTable("dbo.Company");
            DropTable("dbo.Image");
            DropTable("dbo.userCridential");
            DropTable("dbo.User");
            DropTable("dbo.Favourite");
            DropTable("dbo.Product");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Category");
        }
    }
}
