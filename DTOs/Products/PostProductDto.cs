namespace Mormor_Dagnys_Bageri_REST_API.DTOs.Products;

public class PostProductDto
{
    public required string ProductName { get; set; }
    public required double PricePerUnit { get; set; }
    public double ProductWeight { get; set; }
    public int QuantityPerPack { get; set; }
    public DateTime BestBefore { get; set; }
    public DateTime BakedDate { get; set; }
}
