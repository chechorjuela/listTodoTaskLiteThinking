using ApplicationTask.Domain.Common;
using ApplicationTask.Domain.Enums;

namespace ApplicationTask.Domain.Entities;

public class TaskTodo : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public State State { get; set; }
}