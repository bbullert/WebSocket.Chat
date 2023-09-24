using Chat.Data.Entities;

namespace Chat.Data.Repositories
{
    public interface IChatMessageRepository
    {
        Task<IEnumerable<Message>> GetLatestChatMessages(int chatId, int offset, int count);
    }
}