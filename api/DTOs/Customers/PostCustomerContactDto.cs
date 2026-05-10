using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Customers;

public class PostCustomerContactDto
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public string FirstName { get; set; } = "";
    [Required]
    public string LastName { get; set; } = "";
    [Required]
    public string Phone { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
}
