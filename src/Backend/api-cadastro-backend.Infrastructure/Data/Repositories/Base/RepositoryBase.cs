using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Domain.Models.Base;
using api_cadastro_backend.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace api_cadastro_backend.Infrastructure.Data.Repositories.Base;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    protected DataContext DataContext { get; set; }
    public DbSet<TEntity> DbSet { get; set; }

    public RepositoryBase(DataContext dataContext)
    {
        DataContext = dataContext;
        DbSet = DataContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        if (entity.Id == null) // atribuindo o usuario dentro do banco
        {
            DbSet.Entry(entity).State = EntityState.Added;
            await DbSet.AddAsync(entity);
        }
        else // caso ele exista dentro do banco, ele ira atualizar as informações
        {
            DbSet.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }
        await DataContext.SaveChangesAsync();
        return entity;
    }

    public async ValueTask<TEntity> GetByIdAsync(long? id)
        => await DbSet.AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<IEnumerable<TEntity>> GetAsync() 
        => await DbSet.AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task DeleteAsync(long? id)
    {
        var entity = await GetByIdAsync(id);
        DbSet.Remove(entity);
        await DataContext.SaveChangesAsync();
    }

    public async ValueTask<bool> ExistsByIdAsync(long? id) 
        => await DbSet.AnyAsync(x => x.Id == id);

}