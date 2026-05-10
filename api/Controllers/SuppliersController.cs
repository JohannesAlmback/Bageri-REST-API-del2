using Microsoft.AspNetCore.Mvc;
using core.Entities;
using api.DTOs.SupplierContacts;
using api.DTOs.Suppliers;
using core.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Controllers;

[Route("api/suppliers")]
[ApiController]
public class SuppliersController(IGenericRepository<Supplier> repo, IGenericRepository<SupplierContact> scRepo, ISupplierRepository sRepo) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllSuppliers()
    {
        try
        {
            var suppliers = await sRepo.GetSuppliersWithCommoditiesAsync();

            var result = suppliers.Select(s => new
            {
                s.Id,
                s.SupplierName,
                s.Address,
                s.PostalCode,
                s.City,
                s.Phone,
                s.Email,

                Contact = s.SupplierContact!.Select(sc => new
                {
                    sc.FirstName,
                    sc.LastName,
                    sc.Phone,
                    sc.Email
                }),

                Commodities = s.SupplierPrice!.Select(c => new
                {
                    c.Commodity!.CommodityName,
                    c.ItemNumber,
                    c.Description,
                    c.PricePerKilo
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
    public async Task<ActionResult> FindSupplier(int id)
    {
        try
        {
            var supplier = await sRepo.GetSupplierWithCommoditiesByIdAsync(id);

            if (supplier is null) return NotFound($"Det finns ingen leverantör med id {id}.");

            var supplierToReturn = new
            {
                supplier.Id,
                supplier.SupplierName,

                Contact = supplier.SupplierContact!.Select(c => new
                {
                    c.Id,
                    c.FirstName,
                    c.LastName,
                    c.Phone,
                    c.Email
                }),

                Commodities = supplier.SupplierPrice!.Select(p => new
                {
                    p.Commodity!.CommodityName,
                    p.ItemNumber,
                    p.Description,
                    p.PricePerKilo
                })
            };

            return Ok(new { Success = true, StatusCode = 200, Items = 1, Data = supplierToReturn });
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }
    }

    [HttpPost()]
    public async Task<ActionResult> AddSupplier(PostSupplierDto model)
    {
        try
        {
            Supplier supplier = new()
            {
                SupplierName = model.SupplierName,
                Address = model.Address,
                PostalCode = model.PostalCode,
                City = model.City,
                Phone = model.Phone,
                Email = model.Email
            };

            repo.Add(supplier);

            if (await repo.SaveAllAsync()) return Ok("Leverantören har sparats");

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }
    }

    [HttpPost("contact")]
    public async Task<ActionResult> AddSupplierContact(PostSupplierContactDto model)
    {
        try
        {
            var supplier = await repo.FindByIdAsync(model.SupplierId);

            if (supplier is null) return NotFound("Leverantör finns ej");

            SupplierContact supplierContact = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Supplier = supplier
            };

            scRepo.Add(supplierContact);

            if (await scRepo.SaveAllAsync()) return Ok("Kontakten har sparats");

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }
}

