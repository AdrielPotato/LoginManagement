using LoginManagement.Application.Repositories;
using LoginManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Infrastructure.Persistence.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAsync(User user)
        {
            _dbContext.Users.Add(user);
            return (await _dbContext.SaveChangesAsync()) == 1;

        }
    }
}
