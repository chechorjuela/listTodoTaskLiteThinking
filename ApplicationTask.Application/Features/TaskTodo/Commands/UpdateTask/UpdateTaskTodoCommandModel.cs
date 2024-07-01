namespace ApplicationTask.Application.Features.TaskTodo.Commands.UpdateTask;

public class UpdateTaskTodoCommandModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}