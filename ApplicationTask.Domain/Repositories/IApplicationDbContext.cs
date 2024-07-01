using Microsoft.EntityFrameworkCore;

namespace ApplicationTask.Application.Features.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TaskTodo> TaskTodo { get; set;  }
}
