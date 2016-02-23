namespace Api.Migrations
{
    using Api.Common;
    using Api.DAL.DTO;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Api.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Api.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data. E.g.

            context.Catalogs.AddOrUpdate(
                 p => new { p.Name, p.Desc, p.CreatedAt },
                 new Catalog { Name = "Restoran1 Menu Catalog", Desc = "Restoran1 menu catalog description", CreatedAt = DateTime.Now },
                 new Catalog { Name = "Restoran2 Menu Catalog", Desc = "Restoran2 menu catalog description", CreatedAt = DateTime.Now },
                 new Catalog { Name = "Restoran3 Menu Catalog", Desc = "Restoran3 menu catalog description", CreatedAt = DateTime.Now },
                 new Catalog { Name = "Restoran4 Menu Catalog", Desc = "Restoran4 menu catalog description", CreatedAt = DateTime.Now }
               );

            context.Items.AddOrUpdate(
                p => new { p.Name, p.Desc },
                new Item { Name = "Celery", Desc = "Description of celery" },
                new Item { Name = "Spinach", Desc = "Description ofspinach" },
                new Item { Name = "Lemonades", Desc = "Description of Lemonades" },
                new Item { Name = "Trios", Desc = "Description of Trios" },
                new Item { Name = "Dark Chocolate", Desc = "Description of Dark Chocolate" },
                new Item { Name = "Just Vanilla", Desc = "Description of Just Vanilla" },
                new Item { Name = "Coke", Desc = "Description of coke" },
                new Item { Name = "Orange Juice", Desc = "Description of orange juice" },
                new Item { Name = "Test item", Desc = "char test ş,Ş,ı,İ,ğ,Ğ,ö,Ö,ü,Ü,ç,Ç" }
          );

            context.Categories.AddOrUpdate(
              p => new { p.Name, p.Desc, p.CatalogId },
              new Category { Name = "Vegetables", Desc = "Description of vegetables", CatalogId = 1 },
              new Category { Name = "Beverages", Desc = "Description of beverages", CatalogId = 1 },
              new Category { Name = "Desserts", Desc = "Description of desserts", CatalogId = 1 },
              new Category { Name = "Cookies", Desc = "Description of cookies", CatalogId = 1, ParentId = 3 },
              new Category { Name = "Ice Creams", Desc = "Description of ice creams", CatalogId = 1, ParentId = 3 }
            );

            context.Properties.AddOrUpdate(
             p => new { p.Key, p.Value },
             new Property { Key = Key.Tag, Value = "Menu of the day" },
             new Property { Key = Key.Tag, Value = "Best seller" }
            );

        }
    }
}
