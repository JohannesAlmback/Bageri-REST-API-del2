using core.Entities;

namespace core.Interfaces;

public interface ISupplierRepository
{
    Task<IReadOnlyList<Supplier>> GetSuppliersWithCommoditiesAsync();
    Task<Supplier?> GetSupplierWithCommoditiesByIdAsync(int id);
}
