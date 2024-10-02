using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Domain.Models;

namespace api_cadastro_backend.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepositoryBase<Usuario>
{
    Task<bool> AnyExistUserByEmail(string email);
    Task<Usuario> GetByEmailAsync(string email);
}