using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using core.Entities;
using core.Entities.Orders;

namespace infrastructure.Data;

public class MormorDagnysContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Commodity> Commodities { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierPrice> SupplierPrices { get; set; }
    public DbSet<SupplierContact> SupplierContacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerContact> CustomerContacts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<SupplierPrice>().HasKey(c => new { c.SupplierId, c.CommodityId });
        modelBuilder.Entity<Order>().HasMany(o => o.OrderItems).WithOne(oi => oi.Order).HasForeignKey(oi => oi.OrderId);

        base.OnModelCreating(modelBuilder);
    }
}
