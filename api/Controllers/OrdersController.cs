using Microsoft.AspNetCore.Mvc;
using api.DTOs.Orders;
using core.Entities;
using core.Entities.Orders;
using core.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController(IGenericRepository<Order> repo, IGenericRepository<Customer> cRepo, IGenericRepository<Product> pRepo, IOrderRepository oRepo) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> FindOrder([FromQuery] string? orderNumber, [FromQuery] DateTime? date, [FromQuery] int? id)
    {
        var orders = await oRepo.SearchOrdersAsync(orderNumber, date, id);

        var result = orders.Select(o => new
        {
            o.Id,
            o.OrderNumber,
            OrderDate = o.OrderDate.ToString("yyyy-MM-dd"),
            Customer = o.Customer?.CustomerName,

            Items = o.OrderItems.Select(i => new
            {
                i.Product?.ProductName,
                i.Quantity,
                i.Price,
                Total = i.TotalAmont
            }),

            SubTotal = o.SubTotalAmount
        });

        return Ok(new
        {
            Success = true,
            Items = result.Count(),
            Data = result
        });
    }

    [HttpPost()]
    public async Task<ActionResult> CreateOrder(PostOrderDto model)
    {
        var customer = await cRepo.FindByIdAsync(model.CustomerId);
        if (customer is null) return NotFound("Hittar inte kund");

        Order order = new()
        {
            OrderNumber = Guid.NewGuid().ToString(),
            CustomerId = model.CustomerId,
            OrderDate = DateTime.UtcNow,
            OrderItems = new List<OrderItem>()
        };

        foreach (var item in model.Items)
        {
            var product = await pRepo.FindByIdAsync(item.ProductId);
            if (product is null) continue;

            order.OrderItems.Add(new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                Price = product.PricePerUnit
            });
        }

        repo.Add(order);

        if (!await repo.SaveAllAsync())
            return StatusCode(500, "Kunde inte spara order");

        return Ok(new { order.Id, order.OrderNumber });
    }
}
