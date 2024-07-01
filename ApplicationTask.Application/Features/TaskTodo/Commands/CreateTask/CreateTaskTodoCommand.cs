using ApplicationTask.Application.Features.Common;
using ApplicationTask.Application.Features.Common.Interfaces;
using ApplicationTask.Application.Features.Common.Results;
using TaskTodoE = ApplicationTask.Domain.Entities.TaskTodo;

namespace ApplicationTask.Application.Features.TaskTodo.Queries;

public class CreateTaskTodoCommand : CreateTaskTodoCommandModel, IRequest<Result<CreateTaskTodoCommandDto>>
{
    public class CreateTaskTodoCommandHandler(
        IRepository<TaskTodoE> taskTodoRepo
        ) : UseCaseHandler, IRequestHandler<CreateTaskTodoCommand, Result<CreateTaskTodoCommandDto>>
    {
        public async Task<Result<CreateTaskTodoCommandDto>> Handle(CreateTaskTodoCommand request, CancellationToken cancellationToken)
        {
            var taskTodo = new TaskTodoE()
            {
                Title = request.Title,
                Description = request.Descripcion,
            };
            await taskTodoRepo.AddAsync(taskTodo);
            
            var resultData = new CreateTaskTodoCommandDto() { Success = true };
            
            return Succeded(resultData);
        }
    }
}