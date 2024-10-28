using api_cadastro_backend.Application.Factory;
using api_cadastro_backend.Application.UseCases.Usuario;
using api_cadastro_backend.Application.Validation.Usuario;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Domain.Interfaces.Transactions;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using api_cadastro_backend.Infrastructure.Data.Repositories;
using api_cadastro_backend.Infrastructure.Data.Repositories.Base;
using api_cadastro_backend.Infrastructure.Data.UnitOfWork;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api_cadastro_backend.loC;



public static class DependencyInjectionRegister
{
    public static IServiceCollection ConfigureService(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkEF>();
        return services;
    }


    public static IServiceCollection ConfigureUseCasesHandlers(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandlerFactory, UseCaseHandlerFactory>();
        services.AddScoped<IUseCaseHandler<UserCreateRequestDTO, CreatedResponse>,UsuarioPostUseCase>();
        services.AddScoped<IUseCaseHandler<GetByIdRequest, UserGetResponseDTO>, UsuarioGetByIdUseCase>();

        return services;
    }

    public static IServiceCollection ConfigureUseCaseHandlersResponse(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandlerResponse<UserGetResponseDTO>, UsuarioGetUseCase>();

        return services;
    }

    public static IServiceCollection ConfigurationUseCaseHandlersRequest(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandlerRequest<DeleteRequest>, UsuarioDeleteUseCase>();
        return services;
    }

    public static IServiceCollection ConfigureValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserCreateRequestDTO>, CreateUsuarioValidator>();
        return services;
    }
}