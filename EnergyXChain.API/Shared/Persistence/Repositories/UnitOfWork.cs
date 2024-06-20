using BoraCW.API.Bora.Shared.Domain.Repositories;
using EnergyXChain.API.Shared.Persistence.Contexts;

namespace BoraCW.API.Bora.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CompleteAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}