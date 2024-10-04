using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Models.DTOs;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioGetUseCase //: IUseCaseHandler<GetRequest, UserGetResponseDTO>
{
    private readonly IUserRepository _repository;

    public UsuarioGetUseCase(IUserRepository repository)
    {
        _repository = repository;
    }
    
    // public  Task<IEnumerable<UserGetResponseDTO>> Handle(GetRequest request)
    // {
    // }
}