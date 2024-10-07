using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Models.DTOs;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace api_cadastro_backend.API.Controller;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{

    readonly IUseCaseHandlerFactory _handlerFactory;

    public UserController(IUseCaseHandlerFactory handlerFactory)
    {
        _handlerFactory = handlerFactory;
    }
    
    
    [Route("users")]
    [ProducesResponseType(typeof(UserGetResponseDTO),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers()
    {
        var handler = _handlerFactory.CreateHandler<UserGetResponseDTO>();
        var response = await handler.Handle();
        return Ok(response);
    }
}