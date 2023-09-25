using LoginManagement.Application.Commands.AuthenticateUser;
using LoginManagement.Application.Commands.RegisterUser;
using LoginManagement.Application.Models;
using LoginManagementAPI.Functions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoginManagementAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, ILogger<BaseController> logger) : base(mediator, logger)
        {
        }

        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(Result<AuthenticateUserViewModel>), 200)]
        [ProducesResponseType(typeof(Result<>), 500)]
        [ProducesResponseType(typeof(Result<>), 404)]
        public async Task<JsonResult> Authenticate([FromBody] AuthenticateUserCommand command) => await HandleControllerActions.Execute(this, command);

        [HttpPost("register")]
        [ProducesResponseType(typeof(Result<RegisterUserViewModel>), 200)]
        [ProducesResponseType(typeof(Result<>), 500)]
        [ProducesResponseType(typeof(Result<>), 404)]
        public async Task<JsonResult> Register([FromBody] RegisterUserCommand command) => await HandleControllerActions.Execute(this, command);

        [HttpPost("register-admin")]
        [ProducesResponseType(typeof(Result<RegisterUserViewModel>), 200)]
        [ProducesResponseType(typeof(Result<>), 500)]
        [ProducesResponseType(typeof(Result<>), 404)]
        public async Task<JsonResult> RegisterAdmin([FromBody] RegisterUserCommand command) => await HandleControllerActions.Execute(this, command);

    }
}
