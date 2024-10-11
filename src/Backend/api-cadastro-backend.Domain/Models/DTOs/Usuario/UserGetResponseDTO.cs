using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Interfaces.UseCases.DTO;

namespace api_cadastro_backend.Domain.Models.DTOs.Usuario;

public record UserGetResponseDTO(
    string Name,
    string Email,
    DateTime CreatedOn) : IUseCaseResponse;