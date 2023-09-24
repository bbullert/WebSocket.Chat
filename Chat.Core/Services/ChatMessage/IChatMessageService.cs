using Chat.Core.Dto;

namespace Chat.Core.Services
{
    public interface IChatMessageService
    {
        Task<IEnumerable<Message>> GetLatestChatMessages(int chatId, int offset, int count);
    }
}