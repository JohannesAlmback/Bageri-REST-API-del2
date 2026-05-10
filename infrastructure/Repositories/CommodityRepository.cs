using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using core.Entities;
using core.Interfaces;

namespace infrastructure.Repositories;

public class CommodityRepository(MormorDagnysContext context) : GenericRepository<Commodity>(context), ICommodityRepository
{
    private readonly MormorDagnysContext _context = context;

    public async Task<IReadOnlyList<Commodity>> GetCommoditiesWithSuppliersAsync()
    {
        return await _context.Commodities
            .Include(c => c.SupplierPrice!)
            .ThenInclude(sp => sp.Supplier)
            .ToListAsync();
    }

    public async Task<Commodity?> GetCommodityWithSuppliersByIdAsync(int id)
    {
        return await _context.Commodities
            .Include(c => c.SupplierPrice!)
            .ThenInclude(sp => sp.Supplier)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
