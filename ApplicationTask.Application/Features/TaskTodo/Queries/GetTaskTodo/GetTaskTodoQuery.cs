using ApplicationTask.Application.Features.Common;
using ApplicationTask.Application.Features.Common.Interfaces;
using ApplicationTask.Application.Features.Common.Results;
using Microsoft.Extensions.Configuration;
using TaskTodoE = ApplicationTask.Domain.Entities.TaskTodo;
namespace ApplicationTask.Application.Features.TaskTodo.Queries.GetTaskTodo;

public class GetTaskTodoQuery : IRequest<Result<GetTaskTodoQueryDto>>
{
    public class GetTaskTodoQueryhandler(
        IConfiguration configuration,
        IRepository<TaskTodoE> taskTodoRepository
            ) : UseCaseHandler, IRequestHandler<GetTaskTodoQuery, Result<GetTaskTodoQueryDto>>
    {
        public async Task<Result<GetTaskTodoQueryDto>> Handle(GetTaskTodoQuery request, CancellationToken cancellationToken)
        {
            var tasksTodo = await taskTodoRepository.GetAllAsync();
            var result = tasksTodo
                .Select(x => new GetTaskTodoQueryValueDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                });

            var resultData = new GetTaskTodoQueryDto()
            {
                TaskTodo = result
            };

            return this.Succeded(resultData);
        }
    }
}