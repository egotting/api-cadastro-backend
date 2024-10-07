using System.Runtime.InteropServices.ComTypes;
using api_cadastro_backend.Application.Factory;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
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


    public static IServiceCollection ConfigureUseCasesHandlers(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandlerFactory, UseCaseHandlerFactory>();
        services.AddScoped<IUseCaseHandler<UserGetRequestDTO, UserGetResponseDTO>>();
        return services;
    }
}