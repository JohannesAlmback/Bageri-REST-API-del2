using core.Entities;

namespace core.Interfaces;

public interface ICustomerRepository
{
    Task<IReadOnlyList<Customer>> GetCustomersWithOrdersAsync();
    Task<Customer?> GetCustomerWithOrdersAsync(int id);
}
