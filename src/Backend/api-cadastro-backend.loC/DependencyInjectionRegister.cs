using System.Runtime.InteropServices.ComTypes;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Infrastructure.Data.Repositories;
using api_cadastro_backend.Infrastructure.Data.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api_cadastro_backend.loC;

public static class DependencyInjectionRegister
{
    public static IServiceCollection ConfigureService(
        this IServiceCollection services,
        IConfiguration confguration
        )
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}