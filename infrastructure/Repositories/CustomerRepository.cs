using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using core.Entities;
using core.Interfaces;

namespace infrastructure.Repositories;

public class CustomerRepository(MormorDagnysContext context) : GenericRepository<Customer>(context), ICustomerRepository
{
    private readonly MormorDagnysContext _context = context;

    public async Task<IReadOnlyList<Customer>> GetCustomersWithOrdersAsync()
    {
        return await _context.Customers
            .Include(c => c.CustomerContact)
            .Include(c => c.Order!)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<Customer?> GetCustomerWithOrdersAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.CustomerContact)
            .Include(c => c.Order!)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
