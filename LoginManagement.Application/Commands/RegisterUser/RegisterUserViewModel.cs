using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.RegisterUser
{
    public class RegisterUserViewModel
    {
        public bool IsRegistered { get; set; }

        public RegisterUserViewModel(bool isRegistered)
        {
            IsRegistered = isRegistered;
        }
    }
}
