using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mormor_Dagnys_Bageri_REST_API.Entities;

public class Commodity : BaseEntity
{
    public required string CommodityName { get; set; }
    public List<SupplierPrice> SupplierPrice { get; set; }
}
