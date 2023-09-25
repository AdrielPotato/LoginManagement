using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.AuthenticateUser
{
    public class AuthenticateUserViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
