using api_cadastro_backend.Domain.Models.Base;

namespace api_cadastro_backend.Domain.Interfaces.Repositories.Base;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity?> GetByEmailAsync(string email);
    ValueTask<IEnumerable<TEntity>> GetAsync();
    Task DeleteAsync(string email);
    ValueTask<bool> ExistsByIdAsync(string email);
}