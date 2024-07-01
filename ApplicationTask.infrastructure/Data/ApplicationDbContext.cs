using ApplicationTask.Application.Features.Common.Interfaces;
using ApplicationTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTask.infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<TaskTodo> TaskTodo { get; set; }
}
