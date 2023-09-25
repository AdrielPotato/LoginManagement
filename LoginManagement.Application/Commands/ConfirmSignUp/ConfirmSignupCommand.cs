using LoginManagement.Application.Commands.RegisterAdminUser;
using LoginManagement.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.ConfirmSignUp
{
    public class ConfirmSignupCommand : IRequest<Result<RegisterAdminUserViewModel>>
    {
    }
}
