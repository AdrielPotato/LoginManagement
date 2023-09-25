using LoginManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountAsync(int id);
        Task<Account> GetAccountAsync(string email);
        Task<List<Account>> GetAccountsAsync();
        Task<bool> CreateAsync(Account account);
    }
}
