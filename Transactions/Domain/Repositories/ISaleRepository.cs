using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Repositories;

public interface ISaleRepository: IBaseRepository<Sale, int>
{
    Task<IEnumerable<Sale>> ListAllAsync();
    Task<Sale?> FindByIdAsync(int id);
    Task<IEnumerable<Sale>> ListSalesByCustomerId(int customerId);
    Task<IEnumerable<Sale>> FindBySupplierIdAsync(int supplierId);
}