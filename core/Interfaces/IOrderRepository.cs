using core.Entities.Orders;

namespace core.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderWithItemsAsync(int id);
    Task<IReadOnlyList<Order>> SearchOrdersAsync(string? orderNumber, DateTime? date, int? id);
}
