using AutoMapper;
using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Service;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SupplierResponse> FindAsync(int id)
    {
        var supplier = await _supplierRepository.FindAsync(id);
        if (supplier == null)
            return new SupplierResponse("Supplier does not exist.");
        return new SupplierResponse(supplier);
    }

    public async Task<SupplierResponse> AddAsync(Supplier newSupplier)
    {
        try
        {
            await _supplierRepository.AddAsync(newSupplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(newSupplier);
        }
        catch (Exception exception)
        {
            return new SupplierResponse(exception.Message);
        }
    }

    public async Task<IEnumerable<Supplier>> ListAllAsync()
    {
        return await _supplierRepository.ListAllAsync();
    }

    public async Task<SupplierResponse> FindByUidAsync(string uid)
    {
        var existingSupplier = await _supplierRepository.FindByUid(uid);
        if (existingSupplier == null)
            return new SupplierResponse("Customer does not exist.");
        return new SupplierResponse(existingSupplier);
    }

    public async Task<IEnumerable<Customer>> ListCustomersBySupplierIdAsync(int supplierId)
    {
        return await _supplierRepository.ListCustomersBySupplierIdAsync(supplierId);
    }
}