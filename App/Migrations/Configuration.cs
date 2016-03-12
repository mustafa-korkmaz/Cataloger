namespace App.Migrations
{
    using Common.Enumerations;
    using App.DAL.DTO;
    using App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data. E.g.

            context.Templates.AddOrUpdate(
                t => new { t.Id, t.Type, t.Desc },
                new Template { Id = 1, Type = TemplateType.Default, Desc = "Description of default template" },
                new Template { Id = 2, Type = TemplateType.Food, Desc = "Description of food template" }
                );


            context.Catalogs.AddOrUpdate(
                c => new { c.Id, c.Name, c.Desc, c.CreatedAt, c.TemplateId },
                new Catalog { Id = 1, Name = "Restoran1 Menu Catalog", Desc = "Restoran1 menu catalog description", CreatedAt = DateTime.Now, TemplateId = 2, },
                new Catalog { Id = 2, Name = "Restoran2 Menu Catalog", Desc = "Restoran2 menu catalog description", CreatedAt = DateTime.Now, TemplateId = 2, },
                new Catalog { Id = 3, Name = "Restoran3 Menu Catalog", Desc = "Restoran3 menu catalog description", CreatedAt = DateTime.Now, TemplateId = 2, },
                new Catalog { Id = 4, Name = "Restoran4 Menu Catalog", Desc = "Restoran4 menu catalog description", CreatedAt = DateTime.Now, TemplateId = 2 }
              );


            context.Properties.AddOrUpdate(
                p => new { p.Key, p.Value },
                new Property { Key = Key.Tag, Value = "Menu of the day" },
                new Property { Key = Key.Tag, Value = "Best seller" },
                new Property { Key = Key.Discount, Value = "%10 off" },
                new Property { Key = Key.Image, Value = "Sample image url goes here" },
                new Property { Key = Key.Video, Value = "Sample video url goes here" }
               );

            context.Categories.AddOrUpdate(
              c => new { c.Id, c.Name, c.Desc, c.CatalogId },
              new Category { Id = 1, Name = "Vegetables", Desc = "Description of vegetables", CatalogId = 1 },
              new Category { Id = 2, Name = "Beverages", Desc = "Description of beverages", CatalogId = 1 },
              new Category { Id = 3, Name = "Desserts", Desc = "Description of desserts", CatalogId = 1 },
              new Category { Id = 4, Name = "Cookies", Desc = "Description of cookies", CatalogId = 1, ParentId = 3 },
              new Category { Id = 5, Name = "Ice Creams", Desc = "Description of ice creams", CatalogId = 1, ParentId = 3 }
            );

            context.Items.AddOrUpdate(
               p => new { p.Name, p.Desc, p.CategoryId },
               new Item { Name = "Celery", Desc = "Description of celery", CategoryId = 1 },
               new Item { Name = "Spinach", Desc = "Description ofspinach", CategoryId = 1 },
               new Item { Name = "Lemonades", Desc = "Description of Lemonades", CategoryId = 2 },
               new Item { Name = "Trios", Desc = "Description of Trios", CategoryId = 3 },
               new Item { Name = "Dark Chocolate", Desc = "Description of Dark Chocolate", CategoryId = 4 },
               new Item { Name = "Just Vanilla", Desc = "Description of Just Vanilla", CategoryId = 4 },
               new Item { Name = "Coke", Desc = "Description of coke", CategoryId = 2 },
               new Item { Name = "Orange Juice", Desc = "Description of orange juice", CategoryId = 2 },
               new Item { Name = "Test item", Desc = "char test ş,Ş,ı,İ,ğ,Ğ,ö,Ö,ü,Ü,ç,Ç", CategoryId = 1 }
         );

        }
    }
}
