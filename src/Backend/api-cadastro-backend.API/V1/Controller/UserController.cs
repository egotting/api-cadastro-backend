using api_cadastro_backend.Domain.Interfaces.UseCases;
using api_cadastro_backend.Domain.Interfaces.UseCases.Handler;
using api_cadastro_backend.Domain.Models.DTOs;
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
        var handler = _handlerFactory.CreateHandlerResponse<UserGetResponseDTO>();
        var response = await handler.Handle();
        return Ok(response);
    }
 
    [HttpGet]
    [Route("users/{email}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(UserGetResponseDTO),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsersByEmail([FromRoute] string email, CancellationToken cancellationToken)
    {
        var handler = _handlerFactory.CreateHandler<GetByIdRequest ,UserGetResponseDTO>();
        var response = await handler.Handle(new GetByIdRequest(email), cancellationToken);
        return Ok(response);
    }


    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Route("register")]
    public async Task<IActionResult> CreateUser(
        [FromBody]UserCreateRequestDTO user,
        CancellationToken cancellationToken
        )
    {
        var handler = _handlerFactory.CreateHandler<UserCreateRequestDTO, CreatedResponse>();
        var response = await handler.Handle(user, cancellationToken);
        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("deleteuser/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser([FromRoute]string email)
    {
        var request = new DeleteRequest(email);
        var handler = _handlerFactory.CreateHandlerRequest<DeleteRequest>();
        await handler.Handle(request);
        return NoContent();
    }
}