using EnergyXChain.API.Shared.Domain.Service.Communication;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Services.Communication;

public class SupplierResponse : BaseResponse<Supplier>
{
    public SupplierResponse(Supplier resource) : base(resource)
    {
    }

    public SupplierResponse(string message) : base(message)
    {
    }
}
