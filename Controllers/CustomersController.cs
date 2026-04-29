using Microsoft.AspNetCore.Mvc;
using Mormor_Dagnys_Bageri_REST_API.DTOs.Customers;
using Mormor_Dagnys_Bageri_REST_API.Entities;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;

namespace Mormor_Dagnys_Bageri_REST_API.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController(IGenericRepository<Customer> repo, IGenericRepository<CustomerContact> ccRepo) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult> ListAllCustomers()
    {
        try
        {
            var customers = await repo.ListAllIncludesAsync(c => c.CustomerContact);

            var result = customers.Select(s => new
            {
                s.Id,
                s.CustomerName,
                s.Phone,
                s.Email,
                s.DeliveryAddress,
                s.DeliveryPotalCode,
                s.DeliveryCity,
                s.InvoiceAddress,
                s.InvoicePostalCode,
                s.InvoiceCity,

                Contact = s.CustomerContact.Select(sc => new
                {
                    sc.FirstName,
                    sc.LastName,
                    sc.Phone,
                    sc.Email
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
        var customer = await repo.FindByIdWithIncludesAsync(id, c => c.CustomerContact);

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

            Contact = customer.CustomerContact.Select(cc => new
            {
                cc.FirstName,
                cc.LastName,
                cc.Phone,
                cc.Email
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
    public async Task<ActionResult> AddCustomerContact(PostCustomerContactDto model)
    {
        try
        {
            var customer = await repo.FindByIdAsync(model.CustomerId);

            if (customer is null) return NotFound("Kund finns ej");

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