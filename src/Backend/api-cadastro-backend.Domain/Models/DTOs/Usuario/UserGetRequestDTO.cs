using api_cadastro_backend.Domain.Interfaces.UseCases.DTO;

namespace api_cadastro_backend.Domain.Models.DTOs.Usuario;

public class UserGetRequestDTO() : IUseCaseRequest
{
    public string Email { get; set; } = string.Empty;
}
