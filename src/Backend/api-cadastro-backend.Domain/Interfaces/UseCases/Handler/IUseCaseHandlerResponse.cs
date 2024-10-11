using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Domain.Interfaces.UseCases.Handler;

public interface IUseCaseHandlerResponse<TResponse>
{
    Task<List<TResponse>> Handle();
}