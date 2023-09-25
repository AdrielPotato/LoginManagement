using FluentValidation;
using LoginManagement.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginManagementAPI.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
            };
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Internal Server Error",
                Errors = new List<string> { "An error occurred while processing your request" }
            };

            context.Result = new BadRequestObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as LoginManagement.Core.ValueObjects.ValidationException;

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Invalid Request",
                Errors = exception.Errors
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var errors = context.ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Invalid Request",
                Errors = errors
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var errors = context.ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Resource Not Found",
                Errors = errors
            };

            context.Result = new NotFoundObjectResult(response);
            context.ExceptionHandled = true;
        }
    }
}
