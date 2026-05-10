using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Suppliers;

public class PostSupplierDto
{
    [Required]
    public string SupplierName { get; set; } = "";
    [Required]
    public string Address { get; set; } = "";
    [Required]
    public string PostalCode { get; set; } = "";
    [Required]
    public string City { get; set; } = "";
    [Required]
    public string Phone { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
}
