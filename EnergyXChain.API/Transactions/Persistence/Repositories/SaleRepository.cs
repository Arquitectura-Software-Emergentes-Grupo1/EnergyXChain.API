using EnergyXChain.API.Shared.Persistence.Contexts;
using EnergyXChain.API.Shared.Persistence.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnergyXChain.API.Transactions.Persistence.Repositories;

public class SaleRepository : BaseRepository<Sale, int>, ISaleRepository
{
    public SaleRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Sale>> ListAllAsync()
    {
        return await Entities
            .Include(s => s.Customer)
            .Include(s => s.Supplier)
            .Include(s => s.Plan)
            .ToListAsync();
    }

    public async Task<Sale?> FindByIdAsync(int id)
    {
        return await Entities
            .Include(s => s.Customer)
            .Include(s => s.Supplier)
            .Include(s => s.Plan)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}