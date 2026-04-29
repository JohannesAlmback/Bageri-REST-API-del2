using Mormor_Dagnys_Bageri_REST_API.DTOs.SupplierPrice;

namespace Mormor_Dagnys_Bageri_REST_API.DTOs.Commodities;

public class PostCommodityDto
{
    public string CommodityName { get; set; }
    public List<PostSupplierPriceDto> Suppliers { get; set; }
}
