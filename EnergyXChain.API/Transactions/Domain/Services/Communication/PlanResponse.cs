using EnergyXChain.API.Shared.Domain.Service.Communication;
using EnergyXChain.API.Transactions.Domain.Models;

namespace EnergyXChain.API.Transactions.Domain.Services.Communication;

public class PlanResponse : BaseResponse<Plan>
{
    public PlanResponse(Plan resource) : base(resource)
    {
    }

    public PlanResponse(string message) : base(message)
    {
    }
}