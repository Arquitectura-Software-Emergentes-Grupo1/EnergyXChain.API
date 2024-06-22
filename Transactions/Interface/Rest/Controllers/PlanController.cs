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
[SwaggerTag("Controller for Plans - CRUD 💎")]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;
    private readonly IMapper _mapper;

    public PlanController(IPlanService planService, IMapper mapper)
    {
        _planService = planService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PlanResource>> GetPlans()
    {
        return _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(await _planService.ListAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlanById(int id)
    {
        var plan = await _planService.FindAsync(id);
        if (!plan.Success)
            return BadRequest(plan.Message);
        var mappedResultResource = _mapper.Map<Plan, PlanResource>(plan.Resource!);
        return Ok(mappedResultResource);
    }

    [HttpPost]
    public async Task<IActionResult> PostPlan([FromBody, SwaggerRequestBody("")] CreatePlanResource createPlanResource)
    {
        var createPlan = _mapper.Map<CreatePlanResource, Plan>(createPlanResource);
        var plan = await _planService.AddAsync(createPlan);
        if (!plan.Success)
            return BadRequest(plan.Message);
        return Ok(plan.Resource);
    }
}