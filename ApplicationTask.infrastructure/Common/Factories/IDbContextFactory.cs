using Microsoft.EntityFrameworkCore;

namespace ApplicationTask.infrastructure.Common.Factories;

public interface IDbContextFactory
{
    DbContext Create();

}