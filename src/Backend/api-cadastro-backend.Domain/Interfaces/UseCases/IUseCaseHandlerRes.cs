using api_cadastro_backend.Domain.Models;

namespace api_cadastro_backend.Domain.Interfaces.UseCases;

public interface IUseCaseHandlerRes<TResponse> 
    where TResponse : IUseCaseResponse
{
    Task<IEnumerable<Usuario>> Handle();
}