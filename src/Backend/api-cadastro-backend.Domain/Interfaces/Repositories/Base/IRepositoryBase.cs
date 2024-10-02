using api_cadastro_backend.Domain.Models.Base;

namespace api_cadastro_backend.Domain.Interfaces.Repositories.Base;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> GetByIdAsync(long? id);
    ValueTask<IEnumerable<TEntity>> GetAsync();
    Task DeleteAsync(long? id);
    ValueTask<bool> ExistsByIdAsync(long? id);
}