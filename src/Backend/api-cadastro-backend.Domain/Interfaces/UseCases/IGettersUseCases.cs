using api_cadastro_backend.Domain.Models;

namespace api_cadastro_backend.Domain.Interfaces.UseCases;

public interface IGettersUseCase
{
    public Task<IEnumerable<Usuario>> GetAllUsers();
    public Task<Usuario> GetUserById(int id);
    public Task<Usuario> GetUserByEmail(string email);
}