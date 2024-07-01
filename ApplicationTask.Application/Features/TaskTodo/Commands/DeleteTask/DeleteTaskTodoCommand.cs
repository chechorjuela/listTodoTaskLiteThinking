using ApplicationTask.Application.Features.Common;
using ApplicationTask.Application.Features.Common.Interfaces;
using ApplicationTask.Application.Features.Common.Results;
using TaskTodoE = ApplicationTask.Domain.Entities.TaskTodo;

namespace ApplicationTask.Application.Features.TaskTodo.Commands.DeleteTask;

public class DeleteTaskTodoCommand : DeleteTaskTodoCommandModel, IRequest<Result<DeleteTaskTodoCommandDto>>
{
    public class DeleteTaskTodoCommandHandler(
        IRepository<TaskTodoE> taskTodoRepo
        )
        : UseCaseHandler, IRequestHandler<DeleteTaskTodoCommand, Result<DeleteTaskTodoCommandDto>>
    {
        public async Task<Result<DeleteTaskTodoCommandDto>> Handle(DeleteTaskTodoCommand request, CancellationToken cancellationToken)
        {

            var taskDelete = await taskTodoRepo.GetByIdAsync(request.Id);
            
            await taskTodoRepo.RemoveAsync(taskDelete);
            
            var result = new DeleteTaskTodoCommandDto()
            {
                Success = true
            };

            return Succeded(result);
        }
    }
}