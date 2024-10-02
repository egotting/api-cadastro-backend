using api_cadastro_backend.Domain.Interfaces.UseCases;

namespace api_cadastro_backend.Domain.Models.DTOs;

public record CreatedResponse(long? id) : IUseCaseResponse;