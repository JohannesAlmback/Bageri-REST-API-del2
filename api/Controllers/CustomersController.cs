using Microsoft.AspNetCore.Mvc;
using api.DTOs.Customers;
using core.Entities;
using core.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController(IGenericRepository<Customer> repo, IGenericRepository<CustomerContact> ccRepo, ICustomerRepository cRepo) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllCustomers()
    {
        try
        {
            var customers = await cRepo.GetCustomersWithOrdersAsync();

            var result = customers.Select(c => new
            {
                c.Id,
                c.CustomerName,
                c.Phone,
                c.Email,
                c.DeliveryAddress,
                c.DeliveryPotalCode,
                c.DeliveryCity,
                c.InvoiceAddress,
                c.InvoicePostalCode,
                c.InvoiceCity,

                Contact = c.CustomerContact!.Select(cc => new
                {
                    cc.FirstName,
                    cc.LastName,
                    cc.Phone,
                    cc.Email
                }),

                Orders = c.Order!.Select(o => new
                {
                    OrderDate = o.OrderDate.ToString("yyyy-MM-dd"),
                    o.OrderNumber,
                    Items = o.OrderItems.Select(i => new
                    {
                        i.Product!.ProductName,
                        i.Quantity,
                        i.Price,
                        Total = i.TotalAmont
                    }),
                    o.SubTotalAmount
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
    public async Task<ActionResult> FindCustomer(int id)
    {
        var customer = await cRepo.GetCustomerWithOrdersAsync(id);

        if (customer is null) return NotFound($"Det finns ingen kund med id {id}.");

        var result = new
        {
            customer.Id,
            customer.CustomerName,
            customer.Phone,
            customer.Email,
            customer.DeliveryAddress,
            customer.DeliveryPotalCode,
            customer.DeliveryCity,
            customer.InvoiceAddress,
            customer.InvoicePostalCode,
            customer.InvoiceCity,

            Contact = customer.CustomerContact!.Select(cc => new
            {
                cc.FirstName,
                cc.LastName,
                cc.Phone,
                cc.Email
            }),

            Orders = customer.Order!.Select(o => new
            {
                OrderDate = o.OrderDate.ToString("yyyy-MM-dd"),
                o.OrderNumber,
                Items = o.OrderItems.Select(i => new
                {
                    i.Product!.ProductName,
                    i.Quantity,
                    i.Price,
                    Total = i.TotalAmont
                }),
                o.SubTotalAmount
            })
        };

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer(PostCustomerDto model)
    {
        try
        {
            Customer customer = new()
            {
                CustomerName = model.CustomerName,
                Phone = model.Phone,
                Email = model.Email,
                DeliveryAddress = model.DeliveryAddress,
                DeliveryPotalCode = model.DeliveryPotalCode,
                DeliveryCity = model.DeliveryCity,
                InvoiceAddress = model.InvoiceAddress,
                InvoicePostalCode = model.InvoicePostalCode,
                InvoiceCity = model.InvoiceCity
            };

            repo.Add(customer);

            if (await repo.SaveAllAsync()) return Ok("Kunden har sparats");

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }

    }

    [HttpPost("contact")]
    public async Task<ActionResult> AddOrUpdateCustomerContact(PostCustomerContactDto model)
    {
        try
        {
            var customer = await repo.FindByIdAsync(model.CustomerId);

            if (customer is null) return NotFound("Kund finns ej");

            var updateContact = await ccRepo.FindAsync(c =>
                c.CustomerId == model.CustomerId &&
                c.Email == model.Email);

            if (updateContact is not null)
            {
                updateContact.FirstName = model.FirstName;
                updateContact.LastName = model.LastName;
                updateContact.Phone = model.Phone;

                ccRepo.Update(updateContact);

                if (await ccRepo.SaveAllAsync()) return Ok("Kontakten har uppdaterats");

                return StatusCode(500, "Kunde inte uppdatera kontakt");
            }

            CustomerContact customerContact = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Customer = customer
            };

            ccRepo.Add(customerContact);

            if (await ccRepo.SaveAllAsync()) return Ok("Kontakten har sparats");

            return StatusCode(500, "Något fuffens med servern");
        }
        catch
        {
            return StatusCode(500, "Något fuffens med servern");
        }
    }
}