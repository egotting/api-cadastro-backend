using api_cadastro_backend.Domain.Interfaces.Repositories;
using api_cadastro_backend.Domain.Interfaces.Transactions;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Exception;

namespace api_cadastro_backend.Application.UseCases.Usuario;

public class UsuarioDeleteUseCase : IUseCaseHandlerRequest<DeleteRequest>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioDeleteUseCase(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRequest request)
    {
        _unitOfWork.Begin();
        try
        {
            await _repository.DeleteAsync(request.Email);
            _unitOfWork.Commit();
        }
        catch
        {
            _unitOfWork.CallBack();
            throw;
        }
    }
}