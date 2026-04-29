using Mormor_Dagnys_Bageri_REST_API.Entities;

namespace Mormor_Dagnys_Bageri_REST_API.Interfaces;

public interface ISupplierRepository
{
    Task<IReadOnlyList<Supplier>> GetSuppliersWithCommoditiesAsync();
    Task<Supplier> GetSupplierWithCommoditiesByIdAsync(int id);
}
