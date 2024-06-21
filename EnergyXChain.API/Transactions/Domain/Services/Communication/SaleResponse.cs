using EnergyXChain.API.Shared.Domain.Service.Communication;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Services.Communication;

public class SaleResponse : BaseResponse<Sale>
{
    public SaleResponse(Sale resourse) : base(resourse)
    {
    }

    public SaleResponse(string message) : base(message)
    {
    }
}