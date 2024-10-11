using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioPostUseCase : IUseCaseHandler<UserGetRequestDTO, UserGetResponseDTO>
{
    
    
    public Task<UserGetResponseDTO> Handle(UserGetRequestDTO request)
    {
        throw new NotImplementedException();
    }
}