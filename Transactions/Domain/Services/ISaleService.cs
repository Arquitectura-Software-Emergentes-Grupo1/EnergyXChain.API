using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Domain.Services;

public interface ISaleService
{
    Task<SaleResponse> FindAsync(int id);
    Task<SaleResponse> AddAsync(Sale newSale);
    Task<IEnumerable<Sale>> ListAllAsync();
    Task<IEnumerable<Sale>> ListSalesByCustomerId(int customerId);
    Task<IEnumerable<Sale>> ListSalesBySupplierId(int supplierId);
}