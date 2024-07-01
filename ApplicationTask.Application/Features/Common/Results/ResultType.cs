namespace ApplicationTask.Application.Features.Common.Results;

public enum ResultType
{
    Ok,
    Invalid,
    Unauthorized,
    PartialOk,
    NotFound,
    PermissionDenied,
    Unexpected,
    Created
}