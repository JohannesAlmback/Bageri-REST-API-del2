using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using core.Interfaces;
using infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MormorDagnysContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("sqlitedev"));
    // options.UseNpgsql(builder.Configuration.GetConnectionString("postgresdev"));
}); ;

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ICommodityRepository), typeof(CommodityRepository));
builder.Services.AddScoped(typeof(ISupplierPriceRepository), typeof(SupplierPriceRepository));
builder.Services.AddScoped(typeof(ISupplierRepository), typeof(SupplierRepository));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var seed = new SeedDatabase();
    await seed.InitDb(app.Services);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

app.Run();


