namespace core.Entities;

public class CustomerContact : BaseEntity
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public Customer? Customer { get; set; }
}
