using Chat.Data.Entities;

namespace Chat.Data.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User entity);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}