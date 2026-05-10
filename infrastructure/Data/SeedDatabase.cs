using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using core.Entities;
using System.Reflection;

namespace infrastructure.Data;

public class SeedDatabase
{
    private static readonly JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task InitDb(IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MormorDagnysContext>();

        context.Database.Migrate();

        await SeedSuppliers(context);
        await SeedCommodities(context);
        await SeedSupplierContacts(context);
        await SeedSupplierPrices(context);
        await SeedProducts(context);
        await SeedCustomers(context);
        await SeedCustomerContacts(context);
    }

    public async Task SeedSuppliers(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.Suppliers.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/suppliers.json");
        Console.WriteLine(json);
        var suppliers = JsonSerializer.Deserialize<List<Supplier>>(json, options);

        if (suppliers is not null && suppliers.Count > 0)
        {
            await context.Suppliers.AddRangeAsync(suppliers);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedCommodities(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.Commodities.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/commodities.json");
        var commodities = JsonSerializer.Deserialize<List<Commodity>>(json, options);

        if (commodities is not null && commodities.Count > 0)
        {
            await context.Commodities.AddRangeAsync(commodities);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedSupplierContacts(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.SupplierContacts.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/supplierContacts.json");
        var supplierContacts = JsonSerializer.Deserialize<List<SupplierContact>>(json, options);

        if (supplierContacts is not null && supplierContacts.Count > 0)
        {
            await context.SupplierContacts.AddRangeAsync(supplierContacts);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedSupplierPrices(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.SupplierPrices.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/supplierPrice.json");
        var supplierPrice = JsonSerializer.Deserialize<List<SupplierPrice>>(json, options);

        if (supplierPrice is not null && supplierPrice.Count > 0)
        {
            await context.SupplierPrices.AddRangeAsync(supplierPrice);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedProducts(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.Products.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/products.json");
        var products = JsonSerializer.Deserialize<List<Product>>(json, options);

        if (products is not null && products.Count > 0)
        {
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedCustomers(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.Customers.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/customers.json");
        var customers = JsonSerializer.Deserialize<List<Customer>>(json, options);

        if (customers is not null && customers.Count > 0)
        {
            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedCustomerContacts(MormorDagnysContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (context.CustomerContacts.Any()) return;

        var json = File.ReadAllText(path + @"/Data/Json/customerContacts.json");
        var contacts = JsonSerializer.Deserialize<List<CustomerContact>>(json, options);

        if (contacts is not null && contacts.Count > 0)
        {
            await context.CustomerContacts.AddRangeAsync(contacts);
            await context.SaveChangesAsync();
        }
    }
}
