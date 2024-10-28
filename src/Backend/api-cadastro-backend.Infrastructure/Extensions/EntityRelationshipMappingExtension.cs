using api_cadastro_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api_cadastro_backend.Infrastructure.Extensions;

public static class EntityRelationshipMappingExtension
{
    public static void MapEntityRelationshipMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasIndex(e => e.Email)
            .IsUnique();
    }
}