using AutoMapper;
using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CustomerResponse> AddAsync(Customer newCustomer)
    {
        try
        {
            await _customerRepository.AddAsync(newCustomer);
            await _unitOfWork.CompleteAsync();
            return new CustomerResponse(newCustomer);
        }
        catch (Exception exception)
        {
            return new CustomerResponse(exception.Message);
        }
    }

    public async Task<CustomerResponse> FindAsync(int id)
    {
        var customer = await _customerRepository.FindAsync(id);
        if (customer == null)
            return new CustomerResponse("Customer does not exist.");
        return new CustomerResponse(customer);
    }

    public async Task<IEnumerable<Customer>> ListAllAsync()
    {
        return await _customerRepository.ListAllAsync();
    }

    public async Task<CustomerResponse> FindByUidAsync(string uid)
    {
        var existingCustomer = await _customerRepository.FindByUid(uid);
        if (existingCustomer == null)
            return new CustomerResponse("Customer does not exist.");
        return new CustomerResponse(existingCustomer);
    }
}