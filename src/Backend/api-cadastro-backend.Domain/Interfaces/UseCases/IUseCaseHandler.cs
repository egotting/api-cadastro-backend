namespace api_cadastro_backend.Domain.Interfaces.UseCases;

public interface IUseCaseHandler<TRequest, TResponse>
    where TRequest : IUseCaseRequest
    where TResponse : IUseCaseResponse
{
    Task<TResponse> Execute();
}