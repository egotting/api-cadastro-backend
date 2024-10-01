using api_cadastro_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api_cadastro_backend.Infrastructure.Extensions;

public static class EntityPrimaryKeyMappingExtensions
{
    public static void ConfigurePrimaryKey(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasKey(i => i.Id);
    }
}