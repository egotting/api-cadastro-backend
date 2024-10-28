using api_cadastro_backend.Application.Mappers;
using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.Transactions;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using FluentValidation;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioPostUseCase : IUseCaseHandler<UserCreateRequestDTO, CreatedResponse>
{
    private readonly IValidator<UserCreateRequestDTO> _validator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UsuarioPostUseCase(IValidator<UserCreateRequestDTO> validator, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }


    public async Task<CreatedResponse> Handle(UserCreateRequestDTO request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        _unitOfWork.Begin();
        try
        {
            var entity = request.ToEntity();
            await _userRepository.AddAsync(entity);
            _unitOfWork.Commit();
            return new CreatedResponse(request.Email);
        }
        catch (System.Exception e)
        {
            _unitOfWork.CallBack();
            throw;
        }
    }
    
    
}