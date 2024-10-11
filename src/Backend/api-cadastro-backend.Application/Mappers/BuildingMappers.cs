using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Application.Mappers;

public static class BuildingMappers
{
    public static UserGetResponseDTO ToDto(this Usuario usuario)
    {
        return new UserGetResponseDTO(usuario.Name, usuario.Email, usuario.CreatedOn);
    }
}