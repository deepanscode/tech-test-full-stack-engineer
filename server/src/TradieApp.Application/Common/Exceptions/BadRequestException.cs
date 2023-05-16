using System;
namespace TradieApp.Application.Common.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string? message) : base(message)
    {
    }
}
