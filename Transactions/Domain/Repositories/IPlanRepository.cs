using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan, int>
{
    Task<IEnumerable<Plan>> ListAllAsync();
    Task<Plan?> FindByIdAsync(int id);
}