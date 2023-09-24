using Chat.Core.Dto;

namespace Chat.Core.Services
{
    public interface IChatUserService
    {
        Task<int> CreateAsync(int chatId, int userId);
        Task<IEnumerable<ChatUser>> GetAllAsync();
        Task<ChatUser> GetAsync(int chatId, int userId);
        Task<IEnumerable<User>> GetChatUsersAsync(int chatId);
        Task<IEnumerable<Dto.Chat>> GetUserChatsAsync(int userId);
        bool Remove(int chatId, int userId);
    }
}