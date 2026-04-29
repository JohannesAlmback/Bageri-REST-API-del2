namespace Mormor_Dagnys_Bageri_REST_API.DTOs.Customers;

public class PostCustomerContactDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
