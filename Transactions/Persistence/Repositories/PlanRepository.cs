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
        return await Entities.Include(plan => plan.Supplier).ToListAsync();
    }

    public async Task<Plan?> FindByIdAsync(int id)
    {
        return await Entities.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Plan>> FindBySupplierIdAsync(int supplierId)
    {
        return await Entities.Include(plan => plan.Supplier).Where(plan => plan.SupplierId == supplierId).ToListAsync();
    }
}