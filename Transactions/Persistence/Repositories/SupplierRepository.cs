using EnergyXChain.API.Shared.Persistence.Contexts;
using EnergyXChain.API.Shared.Persistence.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnergyXChain.API.Transactions.Persistence.Repositories;

public class SupplierRepository : BaseRepository<Supplier, int>, ISupplierRepository
{
    public SupplierRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Supplier>> ListAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public async Task<Supplier?> FindByIdAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task<Supplier?> FindByUid(string uid)
    {
        return await Entities.FirstOrDefaultAsync((supplier) => supplier.Uid == uid);
    }
}
