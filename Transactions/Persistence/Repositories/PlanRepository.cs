using EnergyXChain.API.Shared.Persistence.Contexts;
using EnergyXChain.API.Shared.Persistence.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnergyXChain.API.Transactions.Persistence.Repositories;

public class PlanRepository : BaseRepository<Plan, int>, IPlanRepository
{
    public PlanRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Plan>> ListAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public async Task<Plan?> FindByIdAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task<IEnumerable<Plan>> FindBySupplierIdAsync(int supplierId)
    {
        return await Entities.Where(plan => plan.SupplierId == supplierId).ToListAsync();
    }
}