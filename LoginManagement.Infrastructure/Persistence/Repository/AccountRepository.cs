using LoginManagement.Application.Repositories;
using LoginManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoginManagement.Infrastructure.Persistence.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Account> GetAccountAsync(int id)
        {
            return await _dbContext.Accounts.SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<Account> GetAccountAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            return await _dbContext.Accounts.SingleOrDefaultAsync(x => x.Email == email);
        }
        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }
        public async Task<bool> CreateAsync(Account account)
        {
            _dbContext.Accounts.Add(account);
            return (await _dbContext.SaveChangesAsync()) == 1;

        }
    }
}
