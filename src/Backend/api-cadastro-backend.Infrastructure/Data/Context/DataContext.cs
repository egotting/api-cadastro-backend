
using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace api_cadastro_backend.Infrastructure.Data.Context;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigurePrimaryKey();
        modelBuilder.MapEntityRelationshipMapping();
    }
    
}