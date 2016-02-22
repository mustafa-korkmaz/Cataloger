namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCatalogUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogUsers",
                c => new
                    {
                        CatalogId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "varchar"),
                    })
                .PrimaryKey(t => new { t.CatalogId, t.UserId })
                .ForeignKey("dbo.Catalogs", t => t.CatalogId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CatalogId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CatalogUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CatalogUsers", "CatalogId", "dbo.Catalogs");
            DropIndex("dbo.CatalogUsers", new[] { "UserId" });
            DropIndex("dbo.CatalogUsers", new[] { "CatalogId" });
            DropTable("dbo.CatalogUsers");
        }
    }
}
