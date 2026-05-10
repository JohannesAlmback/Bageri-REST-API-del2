using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Products;

public class PostProductDto
{
    [Required]
    public string ProductName { get; set; } = "";
    [Required]
    public double PricePerUnit { get; set; } = 0.00;
    public double ProductWeight { get; set; }
    public int QuantityPerPack { get; set; }
    public DateTime BestBefore { get; set; }
    public DateTime BakedDate { get; set; }
}
