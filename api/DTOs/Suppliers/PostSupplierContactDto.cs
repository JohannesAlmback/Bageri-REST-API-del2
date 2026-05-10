using System.ComponentModel.DataAnnotations;

namespace api.DTOs.SupplierContacts;

public class PostSupplierContactDto
{
    [Required]
    public int SupplierId { get; set; }
    [Required]
    public string FirstName { get; set; } = "";
    [Required]
    public string LastName { get; set; } = "";
    [Required]
    public string Phone { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
}
