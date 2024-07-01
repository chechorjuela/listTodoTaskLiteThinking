using ApplicationTask.Application.Features.Common;
using ApplicationTask.Application.Features.Common.Interfaces;
using ApplicationTask.Application.Features.Common.Results;
using TaskTodoE = ApplicationTask.Domain.Entities.TaskTodo;

namespace ApplicationTask.Application.Features.TaskTodo.Commands.UpdateTask;

public class UpdateTaskTodoCommand : UpdateTaskTodoCommandModel, IRequest<Result<UpdateTaskTodoCommandDto>>
{
    public class UpdateTaskTodoCommandHandler(
        IRepository<TaskTodoE> taskTodoRepo
        ): UseCaseHandler, IRequestHandler<UpdateTaskTodoCommand, Result<UpdateTaskTodoCommandDto>>
    {
        public async Task<Result<UpdateTaskTodoCommandDto>> Handle(UpdateTaskTodoCommand request, CancellationToken cancellationToken)
        {
            var getTask = await taskTodoRepo.GetByIdAsync(request.Id)
                          ?? throw (new ArgumentException("The transaction id does not exist"));

            getTask.Description = request.Description;
            getTask.Title = request.Title;
            
            await taskTodoRepo.UpdateAsync(getTask);
            var result = new UpdateTaskTodoCommandDto()
            {
                Success = true
            };
            return this.Succeded(result);
        }
    }
}