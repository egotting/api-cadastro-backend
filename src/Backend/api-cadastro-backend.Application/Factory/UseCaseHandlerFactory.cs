using api_cadastro_backend.Domain.Interfaces.UseCases.DTO;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace api_cadastro_backend.Application.Factory;

public class UseCaseHandlerFactory : IUseCaseHandlerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public UseCaseHandlerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    public IUseCaseHandler<TRequest, TResponse> CreateHandler<TRequest, TResponse>() 
        where TRequest : IUseCaseRequest 
        where TResponse : IUseCaseResponse
    {
        return _serviceProvider.GetRequiredService<IUseCaseHandler<TRequest, TResponse>>();
    }

    public IUseCaseHandlerResponse<TResponse> CreateHandlerResponse<TResponse>() 
        where TResponse : IUseCaseResponse
    {
        return _serviceProvider.GetRequiredService<IUseCaseHandlerResponse<TResponse>>();
    }

    public IUseCaseHandlerRequest<TRequest> CreateHandlerRequest<TRequest>() where TRequest : IUseCaseRequest
    {
        return _serviceProvider.GetRequiredService<IUseCaseHandlerRequest<TRequest>>();
    }
}