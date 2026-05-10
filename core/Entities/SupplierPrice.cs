using System.Diagnostics.CodeAnalysis;

namespace core.Entities;

public class SupplierPrice : BaseEntity
{
    public int SupplierId { get; set; }
    public int CommodityId { get; set; }
    public required string ItemNumber { get; set; }
    public required double PricePerKilo { get; set; }
    public string Description { get; set; } = "";
    public Supplier? Supplier { get; set; }
    public Commodity? Commodity { get; set; }
}
