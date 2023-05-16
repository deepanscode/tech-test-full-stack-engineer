using System.Runtime.Serialization;

namespace TradieApp.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {
    }
}
