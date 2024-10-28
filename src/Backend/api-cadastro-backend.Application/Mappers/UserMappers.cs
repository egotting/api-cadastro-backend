using api_cadastro_backend.Domain.Models;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;

namespace api_cadastro_backend.Application.Mappers;

public static class UserMappers
{
    public static UserGetResponseDTO ToDto(this Usuario usuario)
    {
        return new UserGetResponseDTO(usuario.Name, usuario.Email, usuario.CreatedOn);
    }

    public static Usuario ToEntity(this UserCreateRequestDTO dto)
    {
        return new Usuario()
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password
        };
    }
}