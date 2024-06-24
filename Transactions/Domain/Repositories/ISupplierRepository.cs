using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Repositories;

public interface ISupplierRepository : IBaseRepository<Supplier, int>
{
    Task<IEnumerable<Supplier>> ListAllAsync();
    Task<Supplier?> FindByIdAsync(int id);
    Task<Supplier?> FindByUid(string uid);
}
