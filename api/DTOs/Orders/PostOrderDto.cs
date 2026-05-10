using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Orders;

public class PostOrderDto
{
    public int CustomerId { get; set; }
    public List<PostOrderItemDto> Items { get; set; } = [];
}
