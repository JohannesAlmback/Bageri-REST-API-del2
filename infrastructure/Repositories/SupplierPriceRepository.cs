using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using core.Entities;
using core.Interfaces;

namespace infrastructure.Repositories;

public class SupplierPriceRepository(MormorDagnysContext context) : GenericRepository<SupplierPrice>(context), ISupplierPriceRepository
{
    private readonly MormorDagnysContext _context = context;

    public async Task<SupplierPrice?> GetIdsAsync(int commodityId, int supplierId)
    {
        return await _context.SupplierPrices
            .FirstOrDefaultAsync(sp => sp.CommodityId == commodityId && sp.SupplierId == supplierId);
    }
}
