using core.Entities;

namespace core.Interfaces;

public interface ICommodityRepository
{
    Task<IReadOnlyList<Commodity>> GetCommoditiesWithSuppliersAsync();
    Task<Commodity?> GetCommodityWithSuppliersByIdAsync(int id);
}
