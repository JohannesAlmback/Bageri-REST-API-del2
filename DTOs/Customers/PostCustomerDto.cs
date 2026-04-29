namespace Mormor_Dagnys_Bageri_REST_API.DTOs.Customers;

public class PostCustomerDto
{
    public string CustomerName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string DeliveryAddress { get; set; }
    public string DeliveryPotalCode { get; set; }
    public string DeliveryCity { get; set; }
    public string InvoiceAddress { get; set; }
    public string InvoicePostalCode { get; set; }
    public string InvoiceCity { get; set; }
}
