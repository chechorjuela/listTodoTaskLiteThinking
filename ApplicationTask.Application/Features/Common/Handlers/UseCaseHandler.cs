using ApplicationTask.Application.Features.Common.Results;

namespace ApplicationTask.Application.Features.Common;

public class UseCaseHandler
{
    public Result<T> NotFound<T>(string error = null)
    {
        return new Result<T>(default, ResultType.NotFound, error ?? "Not Found.");
    }

    public Result<T> Invalid<T>(string error = null)
    {
        return new Result<T>(default, ResultType.Invalid, error ?? "Invalid.");
    }

    public Result<T> Succeded<T>(T data)
    {
        return new Result<T>(data, ResultType.Ok);
    }

    public Result<T> Created<T>(T data)
    {
        return new Result<T>(data, ResultType.Created);
    }
}