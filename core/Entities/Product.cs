namespace core.Entities;

public class Product : BaseEntity
{
    public required string ProductName { get; set; }
    public required double PricePerUnit { get; set; }
    public double ProductWeight { get; set; }
    public int QuantityPerPack { get; set; }
    public DateTime BestBefore { get; set; }
    public DateTime BakedDate { get; set; }
}
