namespace Mormor_Dagnys_Bageri_REST_API.Entities;

public class Customer : BaseEntity
{
    public required string CustomerName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string DeliveryAddress { get; set; }
    public string DeliveryPotalCode { get; set; }
    public string DeliveryCity { get; set; }
    public string InvoiceAddress { get; set; }
    public string InvoicePostalCode { get; set; }
    public string InvoiceCity { get; set; }
    public List<CustomerContact> CustomerContact { get; set; }

}
