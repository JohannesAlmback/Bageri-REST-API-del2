using Microsoft.EntityFrameworkCore;
using Mormor_Dagnys_Bageri_REST_API.Data;
using Mormor_Dagnys_Bageri_REST_API.Entities;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Repositories;

public class SupplierPriceRepository(MormorDagnysContext context) : GenericRepository<SupplierPrice>(context), ISupplierPriceRepository
{
    private readonly MormorDagnysContext _context = context;

    public async Task<SupplierPrice> GetIdsAsync(int commodityId, int supplierId)
    {
        return await _context.SupplierPrices
            .FirstOrDefaultAsync(sp => sp.CommodityId == commodityId && sp.SupplierId == supplierId);
    }
}
