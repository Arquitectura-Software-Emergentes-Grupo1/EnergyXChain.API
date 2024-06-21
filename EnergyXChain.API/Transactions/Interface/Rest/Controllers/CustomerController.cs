using AutoMapper;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Resources.Create;
using EnergyXChain.API.Transactions.Resources.Show;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace EnergyXChain.API.Transactions.Interface.Rest.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Controller for Customers - CRUD 💎")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CustomerResource>> GetCustomers()
    {
        return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(await _customerService.ListAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.FindAsync(id);
        if (!customer.Success)
            return BadRequest(customer.Message);
        var mappedResultResource = _mapper.Map<Customer, CustomerResource>(customer.Resource!);
        return Ok(mappedResultResource);
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomer([FromBody, SwaggerRequestBody("")] CreateCustomerResource createCustomerResource)
    {
        var createCustomer = _mapper.Map<CreateCustomerResource, Customer>(createCustomerResource);
        var customer = await _customerService.AddAsync(createCustomer);
        if (!customer.Success)
            return BadRequest(customer.Message);
        return Ok(customer.Resource);
    }
}
