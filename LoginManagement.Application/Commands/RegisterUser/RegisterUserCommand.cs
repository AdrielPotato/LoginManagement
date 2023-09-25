using LoginManagement.Application.Commands.AuthenticateUser;
using LoginManagement.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Result<RegisterUserViewModel>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
