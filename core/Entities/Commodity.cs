using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace core.Entities;

public class Commodity : BaseEntity
{
    public required string CommodityName { get; set; }
    public List<SupplierPrice>? SupplierPrice { get; set; }
}
