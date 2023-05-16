using System;
using FluentValidation.Results;

namespace TradieApp.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
    {
        Errors = new List<string>();
    }

    public ValidationException(string errorMessage) : base(errorMessage)
    {
        Errors = new List<string>();
    }

    public List<string> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}

