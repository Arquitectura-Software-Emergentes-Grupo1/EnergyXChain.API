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
        return await Entities.ToListAsync();
    }

    public async Task<Sale?> FindByIdAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task<IEnumerable<Sale>> FindByCustomerIdAsync(int customerId)
    {
        return await Entities.Where(sale => sale.CustomerId == customerId).ToListAsync();
    }
}