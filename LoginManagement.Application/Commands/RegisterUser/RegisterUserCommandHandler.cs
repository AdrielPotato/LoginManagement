using LoginManagement.Application.Models;
using LoginManagement.Application.Repositories;
using LoginManagement.Core.Contants;
using LoginManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace LoginManagement.Application.Commands.RegisterUser
{
    public class RegisterUserCommandhandler : IRequestHandler<RegisterUserCommand, Result<RegisterUserViewModel>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccountRepository _accountRepository;
        public RegisterUserCommandhandler(UserManager<User> userManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
        }
        public async Task<Result<RegisterUserViewModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return Result<RegisterUserViewModel>.Error(500,null,"Invalid Request",new List<string> { "User already exists" });

            User user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return Result<RegisterUserViewModel>.Error(500, null, "Invalid Request", new List<string> { "User creation failed! Please check user details and try again." });
            else
                await _userManager.AddToRoleAsync(user, UserRoleTypes.User);

            //create account
            var account = new Account(request.FirstName, request.LastName, request.Email, request.Username);
            await _accountRepository.CreateAsync(account);

            return new Result<RegisterUserViewModel>(new RegisterUserViewModel(true))
            {
                Success = true,
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Message = "Account creation success"
            };
        }
    }
}
