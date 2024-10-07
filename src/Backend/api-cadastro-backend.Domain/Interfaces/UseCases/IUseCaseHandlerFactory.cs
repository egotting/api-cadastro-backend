namespace api_cadastro_backend.Domain.Interfaces.UseCases;

public interface IUseCaseHandlerFactory
{
    IUseCaseHandler<TRequest, TResponse>? CreateHandler<TRequest, TResponse>()
        where TRequest : IUseCaseRequest
        where TResponse : IUseCaseResponse;

    IUseCaseHandlerRes<TResponse> CreateHandler<TResponse>()
        where TResponse : IUseCaseResponse;
}