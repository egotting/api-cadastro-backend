namespace api_cadastro_backend.Domain.Interfaces.UseCases.Handler;

public interface IUseCaseHandler<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}