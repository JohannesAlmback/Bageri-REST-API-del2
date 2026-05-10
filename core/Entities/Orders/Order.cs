namespace core.Entities.Orders;

public class Order : BaseEntity
{
    public required string OrderNumber { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItem> OrderItems { get; set; } = [];
    public double SubTotalAmount => OrderItems.Sum(i => i.TotalAmont);
}
