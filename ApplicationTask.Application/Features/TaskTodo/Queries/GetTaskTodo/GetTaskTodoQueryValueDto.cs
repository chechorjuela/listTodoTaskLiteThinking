namespace ApplicationTask.Application.Features.TaskTodo.Queries.GetTaskTodo;

public class GetTaskTodoQueryValueDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}