namespace CarShopRepositoryImplementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarAttributesLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttributesId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.AttributesId)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .Index(t => t.AttributesId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarModel = c.String(nullable: false, maxLength: 150),
                        CarMake = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarShopTable",
                c => new
                    {
                        CarId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarId, t.ShopId })
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.ShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarAttributesLinks", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CarShopTable", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.CarShopTable", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CarAttributesLinks", "AttributesId", "dbo.Attributes");
            DropIndex("dbo.CarShopTable", new[] { "ShopId" });
            DropIndex("dbo.CarShopTable", new[] { "CarId" });
            DropIndex("dbo.CarAttributesLinks", new[] { "CarId" });
            DropIndex("dbo.CarAttributesLinks", new[] { "AttributesId" });
            DropTable("dbo.CarShopTable");
            DropTable("dbo.Shops");
            DropTable("dbo.Cars");
            DropTable("dbo.CarAttributesLinks");
            DropTable("dbo.Attributes");
        }
    }
}
