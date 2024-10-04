using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioGetUseCase : IGettersUseCase
{
    private readonly IUserRepository _repository;

    public UsuarioGetUseCase(IUserRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<Domain.Models.Usuario>> GetAllUsers()
    {
        return await _repository.GetAsync();
    }

    public Task<Domain.Models.Usuario> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Models.Usuario> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}