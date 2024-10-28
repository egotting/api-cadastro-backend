using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using FluentValidation;

namespace api_cadastro_backend.Application.Validation.Usuario;

public class CreateUsuarioValidator : AbstractValidator<UserCreateRequestDTO>
{
    private readonly  IUserRepository _userRepository;

    public CreateUsuarioValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required");
        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .Length(6, 50).WithMessage("Password must be between 6 and 50 characters");
    }
}