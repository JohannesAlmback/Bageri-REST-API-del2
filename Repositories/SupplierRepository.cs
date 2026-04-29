using Microsoft.EntityFrameworkCore;
using Mormor_Dagnys_Bageri_REST_API.Data;
using Mormor_Dagnys_Bageri_REST_API.Entities;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Repositories;

public class SupplierRepository(MormorDagnysContext context) : GenericRepository<Supplier>(context), ISupplierRepository
{
    private readonly MormorDagnysContext _context = context;
    public async Task<IReadOnlyList<Supplier>> GetSuppliersWithCommoditiesAsync()
    {
        return await _context.Suppliers
            .Include(sc => sc.SupplierContact)
            .Include(s => s.SupplierPrice)
            .ThenInclude(c => c.Commodity)
            .ToListAsync();
    }

    public async Task<Supplier> GetSupplierWithCommoditiesByIdAsync(int id)
    {
        return await _context.Suppliers
            .Include(sc => sc.SupplierContact)
            .Include(sp => sp.SupplierPrice)
            .ThenInclude(s => s.Commodity)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
