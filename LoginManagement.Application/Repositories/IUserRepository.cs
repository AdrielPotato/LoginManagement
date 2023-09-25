using LoginManagement.Core.Entities;

namespace LoginManagement.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string id);
        Task<bool> CreateAsync(User user);
    }
}
