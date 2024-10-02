using api_cadastro_backend.Domain.Interfaces.UseCases;

namespace api_cadastro_backend.Domain.Models.DTOs;

public class DeleteRequest : IUseCaseRequest
{
    public long Id { get; set; }

    public DeleteRequest(long id)
    {
        Id = id;
    }
}