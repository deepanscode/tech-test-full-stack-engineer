using System;
namespace TradieApp.Application.Common.Wrappers;

public class Response
{
    public IReadOnlyCollection<string> Errors { get; }
    public string Message { get; }

    public Response(IReadOnlyCollection<string> errors, string message)
    {
        Errors = errors;
        Message = message;
    }

    public Response(string message)
    {
        Message = message;
        Errors = Array.Empty<string>();
    }
}

