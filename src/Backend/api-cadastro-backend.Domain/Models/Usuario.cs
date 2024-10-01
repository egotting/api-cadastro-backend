using api_cadastro_backend.Domain.Models.Base;

namespace api_cadastro_backend.Domain.Models;

public class Usuario : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}