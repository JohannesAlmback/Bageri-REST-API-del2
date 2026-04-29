using Microsoft.EntityFrameworkCore;
using Mormor_Dagnys_Bageri_REST_API;
using Mormor_Dagnys_Bageri_REST_API.Data;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;
using Mormor_Dagnys_Bageri_REST_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MormorDagnysContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("sqlitedev"));
}); ;

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ICommodityRepository), typeof(CommodityRepository));
builder.Services.AddScoped(typeof(ISupplierPriceRepository), typeof(SupplierPriceRepository));
builder.Services.AddScoped(typeof(ISupplierRepository), typeof(SupplierRepository));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var seed = new SeedDatabase();
    await seed.InitDb(app);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

app.Run();


