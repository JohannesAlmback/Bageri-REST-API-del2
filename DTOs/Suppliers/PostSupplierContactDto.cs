namespace Mormor_Dagnys_Bageri_REST_API.DTOs.SupplierContacts;

public class PostSupplierContactDto
{
    public int SupplierId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
