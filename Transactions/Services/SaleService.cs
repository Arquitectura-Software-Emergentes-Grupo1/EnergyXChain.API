using AutoMapper;
using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SaleService(ISaleRepository saleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SaleResponse> AddAsync(Sale newSale)
    {
        try
        {
            newSale.Date = DateTime.UtcNow;
            await _saleRepository.AddAsync(newSale);
            await _unitOfWork.CompleteAsync();
            return new SaleResponse(newSale);
        }
        catch (Exception exception)
        {
            return new SaleResponse(exception.Message);
        }
    }

    public async Task<SaleResponse> FindAsync(int id)
    {
        var sale = await _saleRepository.FindByIdAsync(id);
        if (sale == null)
            return new SaleResponse("Sale does not exist.");
        return new SaleResponse(sale);
    }

    public async Task<IEnumerable<Sale>> ListAllAsync()
    {
        return await _saleRepository.ListAllAsync();
    }

    public async Task<IEnumerable<Sale>> ListSalesByCustomerId(int customerId)
    {
        return await _saleRepository.FindByCustomerIdAsync(customerId);
    }
    
    public async Task<IEnumerable<Sale>> ListSalesBySupplierId(int supplierId)
    {
        return await _saleRepository.FindBySupplierIdAsync(supplierId);
    }
}