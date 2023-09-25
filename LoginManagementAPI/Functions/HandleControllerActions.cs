using LoginManagement.Application.Models;
using LoginManagementAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoginManagementAPI.Functions
{
    public static class HandleControllerActions
    {
        public static async Task<JsonResult> Execute<T>(BaseController controller, AuthRequest<T> request)
        {
            var result = await controller._mediator.Send(request);

            return HandleResponse.Execute(result, controller);
        }

        public static async Task<JsonResult> Execute<T>(BaseController controller, IRequest<Result<T>> request)
        {
            var result = await controller._mediator.Send(request);

            return HandleResponse.Execute(result, controller);
        }
    }
}
