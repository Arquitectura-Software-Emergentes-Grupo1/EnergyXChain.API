namespace EnergyXChain.API.Shared.Utils.Communication;

public class ParseEnumResponse<TEnum> where TEnum : Enum
{
    public TEnum? Result { get; set; }
    public string? Message { get; set; }
    public ParseEnumResponse(TEnum result, string? message)
    {
        Result = result;
        Message = message;
    }
    public ParseEnumResponse(string? message)
    {
        Message = message;
    }
}