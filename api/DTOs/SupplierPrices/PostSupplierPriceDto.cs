using System.ComponentModel.DataAnnotations;

namespace api.DTOs.SupplierPrice;

public class PostSupplierPriceDto
{
    [Required]
    public int SupplierId { get; set; }
    [Required]
    public int CommodityId { get; set; }
    [Required]
    public double PricePerKilo { get; set; }
    [Required]
    public string ItemNumber { get; set; } = "";
    public string Description { get; set; } = "";
}
