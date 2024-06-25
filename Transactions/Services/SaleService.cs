using AutoMapper;
using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Models.Entity;
using EnergyXChain.API.Transactions.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IPlanRepository _planRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBlockchainService _blockchainService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SaleService(ISaleRepository saleRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IBlockchainService blockchainService, ISupplierRepository supplierRepository,
        ICustomerRepository customerRepository, IPlanRepository planRepository)
    {
        _saleRepository = saleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _blockchainService = blockchainService;
        _supplierRepository = supplierRepository;
        _customerRepository = customerRepository;
        _planRepository = planRepository;
    }

    public async Task<SaleResponse> AddAsync(Sale newSale)
    {
        var existingSupplier = new Supplier();
        var existingCustomer = await _customerRepository.FindAsync(newSale.CustomerId);
        if (existingCustomer == null)
        {
            return new SaleResponse("Error with customer.");
        }

        var existingPlan = await _planRepository.FindAsync(newSale.PlanId);
        if (existingPlan == null)
            return new SaleResponse("Error with plan.");
        existingSupplier = await _supplierRepository.FindAsync(existingPlan.SupplierId);


        try
        {
            newSale.Date = DateTime.UtcNow;
            await _saleRepository.AddAsync(newSale);
            Console.WriteLine(
                $"supplier: {existingSupplier.WalletAddress} ----- customer: {existingCustomer.WalletAddress}");
            var transaction = new TransactionData
            {
                To = existingSupplier.WalletAddress,
                From = existingCustomer.WalletAddress,
                Value = newSale.Amount
            };
            await _blockchainService.MakeTransaction(transaction);
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

    public async Task<IEnumerable<Sale>> ListByCustomerIdAsync(int customerId)
    {
        return await _saleRepository.ListSalesByCustomerId(customerId);
    }
}