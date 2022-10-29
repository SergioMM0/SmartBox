using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IBoxService, ApplicationServiceBox>();
        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IUserService, UserService>();
    }
}