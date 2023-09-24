using Chat.Core.Dto;

namespace Chat.Core.Services
{
    public interface IChatService
    {
        Task<int> CreateAsync(ChatCreate user);
        Task<IEnumerable<Dto.Chat>> GetAllAsync();
        Task<Dto.Chat> GetAsync(int id);
    }
}