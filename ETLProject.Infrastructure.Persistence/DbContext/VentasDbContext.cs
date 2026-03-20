using ETLProjectDW.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETLProject.Infrastructure.Persistence.DbContext
{
    public class VentasDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().Property(c => c.Id).HasColumnName("CustomerID");
            modelBuilder.Entity<City>().Property(c => c.Id).HasColumnName("CityID");
            modelBuilder.Entity<Country>().Property(c => c.Id).HasColumnName("CountryID");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("ProductID");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("DECIMAL(10,2)");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("CategoryID");
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("OrderID");
            modelBuilder.Entity<OrderStatus>().Property(s => s.Id).HasColumnName("StatusID");
            modelBuilder.Entity<OrderStatus>().ToTable("OrderStatus");
            modelBuilder.Entity<OrderDetail>().Property(od => od.Id).HasColumnName("OrderDetailID");
            modelBuilder.Entity<OrderDetail>().Property(od => od.TotalPrice).HasColumnType("DECIMAL(10,2)");
        }
    }
}