using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoginManagementAPI.Controllers
{
    public class BaseController : Controller
    {
        public readonly IMediator _mediator;
        public readonly ILogger<BaseController> _logger;

        public BaseController(IMediator mediator, ILogger<BaseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
    }
}
