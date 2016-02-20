using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Api.DAL;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Api.DAL.DTO;

namespace Api.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser
    // class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // self reference
            modelBuilder.Entity<Category>()
                    .HasOptional(c => c.Parent)
                    .WithMany(c => c.Children)
                    .HasForeignKey(c => c.ParentId);

            // many-to-many
            modelBuilder.Entity<Item>()
                    .HasMany(i => i.Categories)
                    .WithMany(c => c.Items)
                    .Map(m =>
                    {
                        m.ToTable("ItemCategories");
                        m.MapLeftKey("ItemId");
                        m.MapRightKey("CategoryId");
                    });

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
        }
    }

}