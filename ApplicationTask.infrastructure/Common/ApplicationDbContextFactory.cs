using ApplicationTask.infrastructure.Common.Factories;
using ApplicationTask.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTask.infrastructure.Common;

public class ApplicationDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions<ApplicationDbContext> options;

    public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
    {
        this.options = options;
    }

    public DbContext Create()
    {
        return new ApplicationDbContext(this.options);
    }
}