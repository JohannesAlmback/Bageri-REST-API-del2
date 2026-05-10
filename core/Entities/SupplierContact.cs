using System.Diagnostics.CodeAnalysis;

namespace core.Entities;

public class SupplierContact : BaseEntity
{
    public int SupplierId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public Supplier? Supplier { get; set; }
}
