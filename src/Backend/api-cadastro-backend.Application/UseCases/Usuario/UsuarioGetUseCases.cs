using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioGetUseCase : IUseCaseHandlerRes<UserGetResponseDTO>
{
    private readonly IUserRepository _repository;

    public UsuarioGetUseCase(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Domain.Models.Usuario>> Handle()
    {
        return await _repository.GetAsync() ?? throw new Exception();
    }
}