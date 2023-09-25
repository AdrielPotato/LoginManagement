using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.RegisterAdminUser
{
    public class RegisterAdminUserViewModel
    {
        public bool IsRegistered { get; set; }

        public RegisterAdminUserViewModel(bool isRegistered)
        {
            IsRegistered = isRegistered;
        }
    }
}
