using api_cadastro_backend.Domain.Interfaces.UseCases;

namespace api_cadastro_backend.Domain.Models.DTOs.Usuario;

public class UserGetResponseDTO() : IUseCaseResponse
{
    public string Name { get; set; }= string.Empty;
    public string Email { get; set; }= string.Empty;
    public DateTime StartDate { get; set; }= DateTime.UtcNow;
}