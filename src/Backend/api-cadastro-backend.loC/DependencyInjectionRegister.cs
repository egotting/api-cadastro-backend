using System.Runtime.InteropServices.ComTypes;
using api_cadastro_backend.Application.Factory;
using api_cadastro_backend.Application.UseCases.Usuario;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using api_cadastro_backend.Infrastructure.Data.Repositories;
using api_cadastro_backend.Infrastructure.Data.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api_cadastro_backend.loC;


// TA DANDO PROBLEAM NA INJEÇÃO DE DEPENDENCIA DE ALGUM USECASE

public static class DependencyInjectionRegister
{
    public static IServiceCollection ConfigureService(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }


    public static IServiceCollection ConfigureUseCasesHandlers(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandlerFactory, UseCaseHandlerFactory>();
        // services.AddScoped<IUseCaseHandler<UserGetRequestDTO, UserGetResponseDTO>>();
        return services;
    }

    public static IServiceCollection ConfigureUseCaseHandlersRes(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandlerResponse<UserGetResponseDTO>, UsuarioGetUseCase>();

        return services;
    }
}