using LoginManagement.Application.Commands.RegisterUser;
using LoginManagement.Application.Models;
using LoginManagement.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Queries.ListAccounts
{
    public class ListAccountQueryHandler : IRequestHandler<ListAccountQuery, Result<ListAccountViewModel>>
    {
        private readonly IAccountRepository _accountRespository;
        public ListAccountQueryHandler(IAccountRepository accountRepository) 
        {
            _accountRespository = accountRepository;
        }
        public async Task<Result<ListAccountViewModel>> Handle(ListAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRespository.GetAccountsAsync();

            return new Result<ListAccountViewModel>(new ListAccountViewModel() { Accounts = accounts})
            {
                Success = true,
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Message = Convert.ToString(HttpStatusCode.OK)
            };
        }
    }
}
