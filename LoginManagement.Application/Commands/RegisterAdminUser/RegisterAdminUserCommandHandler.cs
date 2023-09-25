using LoginManagement.Application.Commands.RegisterUser;
using LoginManagement.Application.Models;
using LoginManagement.Application.Repositories;
using LoginManagement.Core.Contants;
using LoginManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Commands.RegisterAdminUser
{
    public class RegisterAdminUserCommandHandler : IRequestHandler<RegisterAdminUserCommand, Result<RegisterAdminUserViewModel>>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountRepository _accountRepository;

        public RegisterAdminUserCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountRepository = accountRepository;
        }

        public async Task<Result<RegisterAdminUserViewModel>> Handle(RegisterAdminUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return Result<RegisterAdminUserViewModel>.Error(500, null, "Invalid Request", new List<string> { "User already exists" });

            User user = new User()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return Result<RegisterAdminUserViewModel>.Error(500, null, "Invalid Request", new List<string> { "User creation failed! Please check user details and try again." });
            

            //role assignment
            if (await _roleManager.RoleExistsAsync(UserRoleTypes.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoleTypes.Admin);
            }

            //create account
            var account = new Account(request.FirstName, request.LastName, request.Email, request.Username);
            await _accountRepository.CreateAsync(account);

            return new Result<RegisterAdminUserViewModel>(new RegisterAdminUserViewModel(true))
            {
                Success = true,
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Message = "Account creation success"
            };
        }
    }
}
