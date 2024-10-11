using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace api_cadastro_backend.API.V1.Controller;

[ApiController]
[Route("/v1/")]
public class UserController : ControllerBase
{

    readonly IUseCaseHandlerFactory _handlerFactory;

    public UserController(IUseCaseHandlerFactory handlerFactory)
    {
        _handlerFactory = handlerFactory;
    }
    
    
    [HttpGet]
    [Route("users")]
    [ProducesResponseType(typeof(UserGetResponseDTO),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers()
    {
        var handler = _handlerFactory.CreateHandler<UserGetResponseDTO>();
        var response = await handler.Handle();
        return Ok(response);
    }
}