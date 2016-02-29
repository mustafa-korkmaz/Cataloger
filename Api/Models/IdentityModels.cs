using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Api.DAL;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Api.DAL.DTO;
using System.Collections.Generic;

namespace Api.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser
    // class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Catalog> Catalogs { get; set; } // n=>n relation
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Template> Templates { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //one-to-many 
            modelBuilder.Entity<Catalog>()
                        .HasRequired(c => c.Template)
                        .WithMany(t => t.Catalogs)
                        .HasForeignKey(c => c.TemplateId);

            // self reference
            modelBuilder.Entity<Category>()
                    .HasOptional(c => c.Parent)
                    .WithMany(c => c.Children)
                    .HasForeignKey(c => c.ParentId);

            // many-to-many
            modelBuilder.Entity<Item>()
                    .HasMany(i => i.Properties)
                    .WithMany(p => p.Items)
                     .Map(m =>
                     {
                         m.ToTable("ItemProperties");
                         m.MapLeftKey("ItemId");
                         m.MapRightKey("PropertyId");
                     });

            // many-to-many
            modelBuilder.Entity<ApplicationUser>()
                    .HasMany(i => i.Catalogs)
                    .WithMany(p => p.Users)
                     .Map(m =>
                     {
                         m.ToTable("UserCatalogs");
                         m.MapLeftKey("UserId");
                         m.MapRightKey("CatalogId");
                     });

            //one-to-many 
            modelBuilder.Entity<Category>()
                        .HasRequired(c => c.Catalog)
                        .WithMany(c => c.Categories)
                        .HasForeignKey(c => c.CatalogId);

            // many-to-many
            modelBuilder.Entity<Category>()
                    .HasMany(i => i.Properties)
                    .WithMany(p => p.Categories)
                     .Map(m =>
                     {
                         m.ToTable("CategoryProperties");
                         m.MapLeftKey("CategoryId");
                         m.MapRightKey("PropertyId");
                     });

            // one-to-many
            modelBuilder.Entity<Item>()
                     .HasRequired(c => c.Category)
                     .WithMany(c => c.Items)
                     .HasForeignKey(c => c.CategoryId);

            // many-to-many
            modelBuilder.Entity<Catalog>()
                    .HasMany(i => i.Properties)
                    .WithMany(p => p.Catalogs)
                     .Map(m =>
                     {
                         m.ToTable("CatalogProperties");
                         m.MapLeftKey("CatalogId");
                         m.MapRightKey("PropertyId");
                     });

        }

    }

}