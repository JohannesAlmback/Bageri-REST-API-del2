using core.Entities;

namespace core.Interfaces;

public interface ISupplierPriceRepository : IGenericRepository<SupplierPrice>
{
    Task<SupplierPrice?> GetIdsAsync(int commodityId, int supplierId);
}
