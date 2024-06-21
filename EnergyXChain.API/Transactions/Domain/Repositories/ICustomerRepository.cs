using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer, int>
{
    Task<IEnumerable<Customer>> ListAllAsync();
    Task<Customer?> FindByIdAsync(int id);
}
