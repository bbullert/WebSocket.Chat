using Chat.Data.Entities;

namespace Chat.Data.Repositories
{
    public interface IChatUserRepository
    {
        Task<int> CreateAsync(int chatId, int userId);
        Task<IEnumerable<ChatUser>> GetAllAsync();
        Task<ChatUser> GetAsync(int chatId, int userId);
        Task<bool> ExistsAsync(int chatId, int userId);
        Task<IEnumerable<User>> GetChatUsersAsync(int chatId);
        Task<IEnumerable<Data.Entities.Chat>> GetUserChatsAsync(int userId);
        bool Remove(int chatId, int userId);
    }
}