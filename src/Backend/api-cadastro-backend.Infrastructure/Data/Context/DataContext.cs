
using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace api_cadastro_backend.Infrastructure.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigurePrimaryKey();
        modelBuilder.MapEntityRelationshipMapping();
    }
    
}