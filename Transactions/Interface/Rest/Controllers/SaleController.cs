using AutoMapper;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Resources.Create;
using EnergyXChain.API.Transactions.Resources.Show;
using EnergyXChain.API.Transactions.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace EnergyXChain.API.Transactions.Interface.Rest.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Controller for Sales - CRUD 💎")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;
    private readonly IMapper _mapper;

    public SaleController(ISaleService saleService, IMapper mapper)
    {
        _saleService = saleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SaleResource>> GetSales()
    {
        return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleResource>>(await _saleService.ListAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSaleById(int id)
    {
        var sale = await _saleService.FindAsync(id);
        if (!sale.Success)
            return BadRequest(sale.Message);
        var mappedResultResource = _mapper.Map<Sale, SaleResource>(sale.Resource!);
        return Ok(mappedResultResource);
    }

    [HttpPost]
    public async Task<IActionResult> PostSale([FromBody, SwaggerRequestBody("")] CreateSaleResource createSaleResource)
    {
        var createSale = _mapper.Map<CreateSaleResource, Sale>(createSaleResource);
        var sale = await _saleService.AddAsync(createSale);
        if (!sale.Success)
            return BadRequest(sale.Message);
        var saleResource = _mapper.Map<Sale, SaleResource>(sale.Resource!);
        return Ok(saleResource);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IEnumerable<SaleResource>> ListSalesByCustomer(int customerId)
    {
        return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleResource>>(await _saleService.ListByCustomerIdAsync(customerId));
    }
}