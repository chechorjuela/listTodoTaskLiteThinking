using ApplicationTask.Application.Common.ResponseMessages;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace ApplicationTask.Application.Common.Exceptions;

public class ValidationException : BadHttpRequestException
{
    public ValidationException(IEnumerable<ValidationFailure> errors)
        : base(Messages.ValidationsErrorMessage)
    {
        Errors = errors;
    }

    public IEnumerable<ValidationFailure> Errors { get; private set; } = [];
}
