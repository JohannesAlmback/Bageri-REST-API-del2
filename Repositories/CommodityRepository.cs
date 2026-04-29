using Microsoft.EntityFrameworkCore;
using Mormor_Dagnys_Bageri_REST_API.Data;
using Mormor_Dagnys_Bageri_REST_API.Entities;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;
using Mormor_Dagnys_Bageri_REST_API.Repositories;

namespace Mormor_Dagnys_Bageri_REST_API;

public class CommodityRepository(MormorDagnysContext context) : GenericRepository<Commodity>(context), ICommodityRepository
{
    private readonly MormorDagnysContext _context = context;

    public async Task<IReadOnlyList<Commodity>> GetCommoditiesWithSuppliersAsync()
    {
        return await _context.Commodities
            .Include(c => c.SupplierPrice)
            .ThenInclude(sp => sp.Supplier)
            .ToListAsync();
    }

    public async Task<Commodity> GetCommodityWithSuppliersByIdAsync(int id)
    {
        return await _context.Commodities
        .Include(c => c.SupplierPrice)
        .ThenInclude(sp => sp.Supplier)
        .FirstOrDefaultAsync(c => c.Id == id);
    }
}
