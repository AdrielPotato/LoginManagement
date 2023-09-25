using LoginManagement.Application.Commands.AuthenticateUser;
using LoginManagement.Application.Models;
using LoginManagement.Application.Queries.ListAccounts;
using LoginManagement.Core.Contants;
using LoginManagementAPI.Functions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginManagementAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : BaseController
    {
        public AccountsController(IMediator mediator, ILogger<BaseController> logger) : base(mediator, logger)
        {
        }

        [Authorize(Roles = UserRoleTypes.Admin)]
        [HttpGet()]
        [ProducesResponseType(typeof(Result<ListAccountViewModel>), 200)]
        [ProducesResponseType(typeof(Result<>), 500)]
        [ProducesResponseType(typeof(Result<>), 404)]
        public async Task<JsonResult> GetAccounts([FromQuery]ListAccountQuery command) => await HandleControllerActions.Execute(this, command);
    }
}
