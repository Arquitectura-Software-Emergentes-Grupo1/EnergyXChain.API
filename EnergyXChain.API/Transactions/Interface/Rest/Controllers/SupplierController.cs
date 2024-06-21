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
[SwaggerTag("Controller for Suppliers - CRUD 💎")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;

    public SupplierController(ISupplierService supplierService, IMapper mapper)
    {
        _supplierService = supplierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SupplierResource>> GetSuppliers()
    {
        return _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(await _supplierService.ListAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierById(int id)
    {
        var supplier = await _supplierService.FindAsync(id);
        if (!supplier.Success)
            return BadRequest(supplier.Message);
        var mappedResultResource = _mapper.Map<Supplier, SupplierResource>(supplier.Resource!);
        return Ok(mappedResultResource);
    }

    [HttpPost]
    public async Task<IActionResult> PostSupplier([FromBody, SwaggerRequestBody("")] CreateSupplierResource createSupplierResource)
    {
        var createSupplier = _mapper.Map<CreateSupplierResource, Supplier>(createSupplierResource);
        var supplier = await _supplierService.AddAsync(createSupplier);
        if (!supplier.Success)
            return BadRequest(supplier.Message);
        return Ok(supplier.Resource);
    }
}