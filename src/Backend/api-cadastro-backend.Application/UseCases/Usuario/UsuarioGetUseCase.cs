using api_cadastro_backend.Application.Mappers;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioGetUseCase : IUseCaseHandlerResponse<UserGetResponseDTO>
{
    private readonly IUserRepository _repository;

    public UsuarioGetUseCase(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<UserGetResponseDTO>> Handle()
    {
        var user = await _repository.GetAsync();
        return user.Select(x => x.ToDto()).ToList();
    }
}