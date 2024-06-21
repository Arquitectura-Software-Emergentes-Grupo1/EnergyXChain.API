using EnergyXChain.API.Shared.Extensions;
using EnergyXChain.API.Shared.Utils.Communication;

namespace EnergyXChain.API.Shared.Utils;

public static class EnumResolver<TEnum> where TEnum : Enum
{
    public static ParseEnumResponse<TEnum> ParseEnum(string? source)
    {
        if (Enum.TryParse(typeof(TEnum), source!.SeparatedSpaceToUpperCamelCase(), out object? result))
            return new ParseEnumResponse<TEnum>((TEnum)result, "Parsed correctly!");
        throw new AppException("Parse is not compatible.");
    }

    public static ParseEnumResponse<TEnum> ParseEnum(string? source, string? inputNameConvention,
        string? outputNameConvention)
    {
        return new ParseEnumResponse<TEnum>("Xd");
    }
}