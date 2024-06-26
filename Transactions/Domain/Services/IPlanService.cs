﻿using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Domain.Services;

public interface IPlanService
{
    Task<PlanResponse> FindAsync(int id);
    Task<PlanResponse> AddAsync(Plan newPlan);
    Task<PlanResponse> RemoveAsync(int id);
    Task<IEnumerable<Plan>> ListAllAsync();
    Task<IEnumerable<Plan>> ListPlansBySupplierIdAsync(int supplierId);
}