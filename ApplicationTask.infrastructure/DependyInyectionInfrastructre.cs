using ApplicationTask.Application.Features.Common.Interfaces;
using ApplicationTask.infrastructure.Common;
using ApplicationTask.infrastructure.Common.Factories;
using ApplicationTask.infrastructure.Data;
using ApplicationTask.infrastructure.LoggingConfig;
using ApplicationTask.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ApplicationTask.infrastructure;

public static class DependyInyectionInfrastructre
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionString");

        Guard.Against.Null(connectionString, message: "Connection string 'SQLConnection' not found.");

        ConfigureSerilog();
        
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }, ServiceLifetime.Scoped);
        
        services.AddTransient<IDbContextFactory, ApplicationDbContextFactory>(s =>
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
                .Options;
            return new ApplicationDbContextFactory(options);
        });
        
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        
        services.AddSingleton(TimeProvider.System);

        return services;
    }
    
    private static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.With(new LoggingEnricher())
            .MinimumLevel.Debug()
            .WriteTo.Console(
                outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}"
            )
            .CreateLogger();
    }
}