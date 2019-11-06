using Microsoft.AspNet.Identity.EntityFramework;
using Pharmacy.DAL.Entities.Identity;
using Pharmacy.DAL.Entities.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.EF
{
    public class MainContext : IdentityDbContext<ApplicationUser>
    {
        public MainContext() { }

        static MainContext()
        {
            Database.SetInitializer<MainContext>(new DbInitializer());
        }

        public MainContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Kind> Kinds { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(p => p.Kinds)
                 .WithMany(k => k.Products)
                 .Map(t => t.MapLeftKey("ProductId")
                 .MapRightKey("KindId")
                 .ToTable("ProductKind"));
            modelBuilder.Entity<Basket>()
                 .HasRequired(a => a.ClientProfile)
                 .WithMany()
                 .HasForeignKey(a => a.ClientProfileId);
            modelBuilder.Entity<ClientProfile>()
                .HasOptional(b => b.Basket)
                .WithMany()
                .HasForeignKey(b => b.BasketId);
            base.OnModelCreating(modelBuilder);
        }
    }

}
