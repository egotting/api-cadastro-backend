using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Interfaces.UseCases.DTO;

namespace api_cadastro_backend.Domain.Models.DTOs;

public class DeleteRequest : IUseCaseRequest
{
    public string Email { get; set; }

    public DeleteRequest(string email)
    {
        Email = email;
    }
}