using api_cadastro_backend.Domain.Interfaces.Repositories.Base;
using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Domain.Models.Base;
using api_cadastro_backend.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace api_cadastro_backend.Infrastructure.Data.Repositories.Base;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Usuario
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

    public async ValueTask<TEntity?> GetByEmailAsync(string email)
        => await DbSet
            .SingleOrDefaultAsync(e => e.Email == email);

    public async ValueTask<IEnumerable<TEntity>> GetAsync() 
        => await DbSet.AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task DeleteAsync(string email)
    {
        var entity = await GetByEmailAsync(email);
        if (entity == null)
        {
            throw new Exception("User not found");
        }
        DbSet.Remove(entity);
        await DataContext.SaveChangesAsync();   
    }

    public async ValueTask<bool> ExistsByIdAsync(string email) 
        => await DbSet.AnyAsync(x => x.Email == email);

}