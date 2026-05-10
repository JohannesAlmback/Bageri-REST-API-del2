using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using core.Entities.Orders;
using core.Interfaces;

namespace infrastructure.Repositories;

public class OrderRepository(MormorDagnysContext context) : GenericRepository<Order>(context), IOrderRepository
{
    private readonly MormorDagnysContext _context = context;

    public async Task<Order?> GetOrderWithItemsAsync(int id)
    {
        return await _context.Orders
            .Include(c => c.Customer)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IReadOnlyList<Order>> SearchOrdersAsync(string? orderNumber, DateTime? date, int? id)
    {
        var query = _context.Orders
            .Include(c => c.Customer)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .AsQueryable();

        if (id.HasValue)
        {
            query = query.Where(o => o.Id == id.Value);
        }

        if (!string.IsNullOrEmpty(orderNumber))
        {
            query = query.Where(o => o.OrderNumber.Contains(orderNumber));
        }

        if (date.HasValue)
        {
            var d = date.Value.Date;
            query = query.Where(o => o.OrderDate.Date == d);
        }

        return await query.ToListAsync();
    }
}
