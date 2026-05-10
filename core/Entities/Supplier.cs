using System.Diagnostics.CodeAnalysis;

namespace core.Entities;

public class Supplier : BaseEntity
{
    public required string SupplierName { get; set; }
    public string Address { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public List<SupplierContact>? SupplierContact { get; set; }
    public List<SupplierPrice>? SupplierPrice { get; set; }
}
