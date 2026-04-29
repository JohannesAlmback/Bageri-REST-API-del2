using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Mormor_Dagnys_Bageri_REST_API.Entities;

namespace Mormor_Dagnys_Bageri_REST_API.Data;

public class SeedDatabase
{
    private static readonly JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MormorDagnysContext>();

        context.Database.Migrate();

        await SeedSuppliers(context);
        await SeedCommodities(context);
        await SeedSupplierContacts(context);
        await SeedSupplierPrices(context);
    }

    public async Task SeedSuppliers(MormorDagnysContext context)
    {
        if (context.Suppliers.Any()) return;

        var json = File.ReadAllText("Data/Json/suppliers.json");
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
        if (context.Commodities.Any()) return;

        var json = File.ReadAllText("Data/Json/commodities.json");
        var commodities = JsonSerializer.Deserialize<List<Commodity>>(json, options);

        if (commodities is not null && commodities.Count > 0)
        {
            await context.Commodities.AddRangeAsync(commodities);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedSupplierContacts(MormorDagnysContext context)
    {
        if (context.SupplierContacts.Any()) return;

        var json = File.ReadAllText("Data/Json/supplierContacts.json");
        var supplierContacts = JsonSerializer.Deserialize<List<SupplierContact>>(json, options);

        if (supplierContacts is not null && supplierContacts.Count > 0)
        {
            await context.SupplierContacts.AddRangeAsync(supplierContacts);
            await context.SaveChangesAsync();
        }
    }

    public async Task SeedSupplierPrices(MormorDagnysContext context)
    {
        if (context.SupplierPrices.Any()) return;

        var json = File.ReadAllText("Data/Json/supplierPrice.json");
        var supplierPrice = JsonSerializer.Deserialize<List<SupplierPrice>>(json, options);

        if (supplierPrice is not null && supplierPrice.Count > 0)
        {
            await context.SupplierPrices.AddRangeAsync(supplierPrice);
            await context.SaveChangesAsync();
        }
    }
}
