using System.Globalization;

namespace BoraCW.API.Bora.Shared.Extensions;

public class AppException : Exception
{
    public AppException() {}
    public AppException(string? message) : base(message) {}
    public AppException(string? message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message!, args)) {}
}