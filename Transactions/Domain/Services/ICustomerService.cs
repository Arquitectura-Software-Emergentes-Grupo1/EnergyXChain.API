using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Domain.Services;

public interface ICustomerService
{
    Task<CustomerResponse> FindAsync(int id);
    Task<CustomerResponse> AddAsync(Customer newCustomer);
    Task<IEnumerable<Customer>> ListAllAsync();
}
