using System.ComponentModel.DataAnnotations;
using api.DTOs.SupplierPrice;

namespace api.DTOs.Commodities;

public class PostCommodityDto
{
    [Required]
    public string CommodityName { get; set; } = "";
    public List<PostSupplierPriceDto> Suppliers { get; set; } = [];
}
