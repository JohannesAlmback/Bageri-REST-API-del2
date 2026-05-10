using Microsoft.AspNetCore.Mvc;
using api.DTOs.Commodities;
using api.DTOs.Products;
using core.Entities;
using core.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllProducts()
    {
        try
        {
            var products = await repo.ListAllAsync();

            var result = products.Select(c => new
            {
                c.Id,
                c.ProductName,
                c.PricePerUnit,
                c.ProductWeight,
                c.QuantityPerPack,
                BestBefore = c.BestBefore.ToString("yyyy-MM-dd"),
                BakedDate = c.BakedDate.ToString("yyyy-MM-dd")
            });

            return Ok(new { Success = true, StatusCode = 200, Items = result.Count(), Data = result });
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindProduct(int id)
    {
        try
        {
            var product = await repo.FindByIdAsync(id);

            if (product is null) return NotFound($"Det finns ingen produkt med id {id}.");

            var result = new
            {
                product.Id,
                product.ProductName,
                product.PricePerUnit,
                product.ProductWeight,
                product.QuantityPerPack,
                BestBefore = product.BestBefore.ToString("yyyy-MM-dd"),
                BakedDate = product.BakedDate.ToString("yyyy-MM-dd")
            };

            return Ok(new { Success = true, StatusCode = 200, Data = result });
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpPost()]
    public async Task<ActionResult> AddProduct(PostProductDto model)
    {
        try
        {
            Product product = new()
            {
                ProductName = model.ProductName,
                PricePerUnit = model.PricePerUnit,
                ProductWeight = model.ProductWeight,
                QuantityPerPack = model.QuantityPerPack,
                BestBefore = DateTime.SpecifyKind(model.BestBefore, DateTimeKind.Utc),
                BakedDate = DateTime.SpecifyKind(model.BakedDate, DateTimeKind.Utc)
            };

            repo.Add(product);

            if (await repo.SaveAllAsync()) return Ok("Produkten har sparats");

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchProductPrice(int id, PatchProductPriceDto model)
    {
        try
        {
            var productPrice = await repo.FindByIdAsync(id);

            productPrice!.PricePerUnit = model.PricePerUnit;

            repo.Update(productPrice);

            if (await repo.SaveAllAsync())
            {
                return Ok("Priset uppdaterades");
            }

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }
    }
}
