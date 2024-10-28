using api_cadastro_backend.Domain.Interfaces.UseCases.DTO;

namespace api_cadastro_backend.Domain.Interfaces.UseCases.Handler;

public interface IUseCaseHandlerFactory
{
    IUseCaseHandler<TRequest, TResponse> CreateHandler<TRequest, TResponse>()
        where TRequest : IUseCaseRequest
        where TResponse : IUseCaseResponse;

    IUseCaseHandlerResponse<TResponse> CreateHandlerResponse<TResponse>()
        where TResponse : IUseCaseResponse;

    IUseCaseHandlerRequest<TRequest> CreateHandlerRequest<TRequest>() 
        where TRequest : IUseCaseRequest;
}