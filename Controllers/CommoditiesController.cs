using Mormor_Dagnys_Bageri_REST_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;
using Mormor_Dagnys_Bageri_REST_API.DTOs.Commodities;

namespace Mormor_Dagnys_Bageri_REST_API.Controllers;

[Route("api/commodities")]
[ApiController]
public class CommoditiesController(IGenericRepository<Commodity> repo, ICommodityRepository cRepo, ISupplierPriceRepository spRepo) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllCommodities()
    {
        try
        {
            var commodities = await cRepo.GetCommoditiesWithSuppliersAsync();

            var result = commodities.Select(c => new
            {
                c.Id,
                c.CommodityName,

                Suppliers = c.SupplierPrice
                    .OrderBy(sp => sp.PricePerKilo)
                    .Select(sp => new
                    {
                        sp.Supplier.SupplierName,
                        sp.PricePerKilo
                    })
            });

            return Ok(new { Success = true, StatusCode = 200, Items = result.Count(), Data = result });
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindCommodity(int id)
    {
        try
        {
            var commodity = await cRepo.GetCommodityWithSuppliersByIdAsync(id);

            if (commodity is null) return NotFound($"Det finns ingen råvara med id {id}.");

            var result = new
            {
                commodity.Id,
                commodity.CommodityName,

                Suppliers = commodity.SupplierPrice
                    .OrderBy(sp => sp.PricePerKilo)
                    .Select(sp => new
                    {
                        sp.Supplier.SupplierName,
                        sp.ItemNumber,
                        sp.Description,
                        sp.PricePerKilo
                    })
            };

            return Ok(new { Success = true, StatusCode = 200, Data = result });
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpPost()]
    public async Task<ActionResult> AddCommodity(PostCommodityDto model)
    {
        try
        {
            Commodity commodity = new()
            {
                CommodityName = model.CommodityName,

                SupplierPrice = [.. model.Suppliers.Select(s => new SupplierPrice
                    {
                        SupplierId = s.SupplierId,
                        PricePerKilo = s.PricePerKilo,
                        ItemNumber = s.ItemNumber,
                        Description = s.Description
                    })]
            };

            repo.Add(commodity);

            if (await repo.SaveAllAsync()) return Ok("Råvaran har sparats");

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpPatch("{commodityId}/{supplierId}")]
    public async Task<ActionResult> PatchSupplierPrice(int commodityId, int supplierId, PatchSupplierPriceDto model)
    {
        try
        {
            var supplierPrice = await spRepo.GetIdsAsync(commodityId, supplierId);

            supplierPrice.PricePerKilo = model.PricePerKilo;

            spRepo.Update(supplierPrice);

            if (await spRepo.SaveAllAsync())
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

