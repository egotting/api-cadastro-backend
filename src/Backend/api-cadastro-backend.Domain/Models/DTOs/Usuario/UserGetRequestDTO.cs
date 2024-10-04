using api_cadastro_backend.Domain.Interfaces.UseCases;

namespace api_cadastro_backend.Domain.Models.DTOs;

public class UserGetRequest() : IUseCaseRequest
{
    public string Email { get; set; }= string.Empty;
}
