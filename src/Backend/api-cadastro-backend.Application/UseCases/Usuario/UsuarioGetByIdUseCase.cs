using api_cadastro_backend.Application.Mappers;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using api_cadastro_backend.Exception;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioGetByIdUseCase : IUseCaseHandler< GetByIdRequest, UserGetResponseDTO>
{
    private readonly IUserRepository _repository;

    public UsuarioGetByIdUseCase(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<UserGetResponseDTO> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        // DANDO ERRO NA BUSCA DO EMAIL
        var userEmail = await _repository.GetByEmailAsync(request.email) ?? throw new NotFoundExceptions("Usuario não achado");
        return userEmail.ToDto();
    }
}