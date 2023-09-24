using Chat.Core.Dto;
using Microsoft.AspNetCore.Http;

namespace Chat.Core.Services
{
    public interface IUserService
    {
        Task<int> CreateAsync(UserCreate user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<IEnumerable<int>> CreateFromJsonAsync(IFormFile file);
    }
}