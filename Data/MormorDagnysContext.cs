using Microsoft.EntityFrameworkCore;
using Mormor_Dagnys_Bageri_REST_API.Entities;

namespace Mormor_Dagnys_Bageri_REST_API.Data;

public class MormorDagnysContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Commodity> Commodities { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierPrice> SupplierPrices { get; set; }
    public DbSet<SupplierContact> SupplierContacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerContact> CustomerContacts { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupplierPrice>().HasKey(c => new { c.SupplierId, c.CommodityId });
        base.OnModelCreating(modelBuilder);
    }
}
