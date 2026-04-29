using Mormor_Dagnys_Bageri_REST_API.Entities;

namespace Mormor_Dagnys_Bageri_REST_API.Interfaces;

public interface ICommodityRepository
{
    Task<IReadOnlyList<Commodity>> GetCommoditiesWithSuppliersAsync();
    Task<Commodity> GetCommodityWithSuppliersByIdAsync(int id);
}
