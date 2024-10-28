using api_cadastro_backend.Domain.Interfaces.UseCases.DTO;

namespace api_cadastro_backend.Domain.Models.DTOs.Usuario;

public class UserCreateRequestDTO : IUseCaseRequest
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}