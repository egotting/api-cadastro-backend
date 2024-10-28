using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Infrastructure.Data.Context;
using api_cadastro_backend.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace api_cadastro_backend.Infrastructure.Data.Repositories;

public class UserRepository : RepositoryBase<Usuario>, IUserRepository
{
    public UserRepository(DataContext dataContext) : base(dataContext)
    {
    }
}