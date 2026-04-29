namespace Mormor_Dagnys_Bageri_REST_API.DTOs.SupplierPrice;

public class PostSupplierPriceDto
{
    public int SupplierId { get; set; }
    public int CommodityId { get; set; }
    public double PricePerKilo { get; set; }
    public string ItemNumber { get; set; }
    public string Description { get; set; }
}
