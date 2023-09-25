using LoginManagement.Application.Commands.RegisterUser;
using LoginManagement.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.RegisterAdminUser
{
    public class RegisterAdminUserCommand : IRequest<Result<RegisterAdminUserViewModel>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
