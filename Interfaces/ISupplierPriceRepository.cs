using Mormor_Dagnys_Bageri_REST_API.Entities;

namespace Mormor_Dagnys_Bageri_REST_API.Interfaces;

public interface ISupplierPriceRepository : IGenericRepository<SupplierPrice>
{
    Task<SupplierPrice> GetIdsAsync(int commodityId, int supplierId);
}
