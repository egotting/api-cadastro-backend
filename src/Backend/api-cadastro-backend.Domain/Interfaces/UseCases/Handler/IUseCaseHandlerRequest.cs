namespace api_cadastro_backend.Domain.Interfaces.UseCases.Handler;

public interface IUseCaseHandlerRequest<TRequest>
{
    Task Handle(TRequest request);
}