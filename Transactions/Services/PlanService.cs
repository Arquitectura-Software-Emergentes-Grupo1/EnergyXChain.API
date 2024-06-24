using AutoMapper;
using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Services;

public class PlanService : IPlanService
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PlanResponse> AddAsync(Plan newPlan)
    {
        try
        {
            await _planRepository.AddAsync(newPlan);
            await _unitOfWork.CompleteAsync();
            return new PlanResponse(newPlan);
        }
        catch (Exception exception)
        {
            return new PlanResponse(exception.Message);
        }
    }

    public async Task<PlanResponse> FindAsync(int id)
    {
        var plan = await _planRepository.FindAsync(id);
        if (plan == null)
            return new PlanResponse("Plan does not exist.");
        return new PlanResponse(plan);
    }

    public async Task<IEnumerable<Plan>> ListAllAsync()
    {
        return await _planRepository.ListAllAsync();
    }

    public async Task<IEnumerable<Plan>> ListPlansBySupplierIdAsync(int supplierId)
    {
        return await _planRepository.FindBySupplierIdAsync(supplierId);
    }
}
