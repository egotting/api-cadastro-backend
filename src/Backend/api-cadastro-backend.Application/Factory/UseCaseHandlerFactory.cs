using api_cadastro_backend.Domain.Interfaces.UseCases;
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

    public IUseCaseHandlerRes<TResponse> CreateHandler<TResponse>() 
        where TResponse : IUseCaseResponse
    {
        return _serviceProvider.GetRequiredService<IUseCaseHandlerRes<TResponse>>();
    }
}