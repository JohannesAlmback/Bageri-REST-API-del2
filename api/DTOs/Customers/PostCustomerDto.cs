using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Customers;

public class PostCustomerDto
{
    [Required]
    public string CustomerName { get; set; } = "";
    [Required]
    public string Phone { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
    [Required]
    public string DeliveryAddress { get; set; } = "";
    [Required]
    public string DeliveryPotalCode { get; set; } = "";
    [Required]
    public string DeliveryCity { get; set; } = "";
    [Required]
    public string InvoiceAddress { get; set; } = "";
    [Required]
    public string InvoicePostalCode { get; set; } = "";
    [Required]
    public string InvoiceCity { get; set; } = "";
}
