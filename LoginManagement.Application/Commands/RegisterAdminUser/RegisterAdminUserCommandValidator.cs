using FluentValidation;
using LoginManagement.Application.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.RegisterAdminUser
{
    public class RegisterAdminUserCommandValidator : AbstractValidator<RegisterAdminUserCommand>
    {
        public RegisterAdminUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required")
                .MaximumLength(100)
                .WithMessage("Invalid FirstName");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("LastName is required")
                .MaximumLength(100)
                .WithMessage("Invalid LastName");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid Email");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
