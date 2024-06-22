namespace EnergyXChain.API.Shared.Domain.Service.Communication;

public class AnyResponse : BaseResponse<Object>
{
    public AnyResponse(object resource) : base(resource)
    {
    }

    public AnyResponse(string message) : base(message)
    {
    }

    public AnyResponse(string message, bool success) : base(message, success)
    {
    }
}