using BLL.Services;
using BLL;
using CORE.DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MediatR;

namespace Task_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register", Name = "Register")]
        public async Task<ActionResult<APIResponse>> Register(RegisterCommand User)
        {
            var dtos = await _mediator.Send(User);
            return Ok(dtos);
        }
        [HttpPost("Login", Name = "Login")]
        public async Task<ActionResult<APIResponse>> Login(LoginQuery User)
        {
            var dtos = await _mediator.Send(User);
            return Ok(dtos);
        }
        [HttpGet("Logout", Name = "Logout")]
        public async Task<ActionResult<APIResponse>> Logout()
        {
            var dtos = await _mediator.Send(new LogoutQuery());
            return Ok(dtos);
        }

    }
}
