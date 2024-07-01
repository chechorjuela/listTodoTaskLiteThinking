using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTask.Shared.Core;

public interface IEngine
{
    T Resolve<T>(IServiceScope scope = null)
        where T : class;

    object Resolve(Type type, IServiceScope scope = null);

    void Configure(IServiceProvider applicationServices);
}