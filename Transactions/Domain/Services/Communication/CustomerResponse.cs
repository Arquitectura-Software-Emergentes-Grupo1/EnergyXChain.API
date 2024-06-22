using EnergyXChain.API.Shared.Domain.Service.Communication;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Services.Communication;

public class CustomerResponse : BaseResponse<Customer>
{
    public CustomerResponse(Customer resourse) : base(resourse)
    {
    }

    public CustomerResponse(string message) : base(message)
    {
    }
}