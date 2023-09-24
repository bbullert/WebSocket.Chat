using Chat.Core.Dto;
using Chat.Data.Repositories;

namespace Chat.Core.Services
{
    public partial class ChatMessageService : IChatMessageService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IChatRepository _chatRepository;

        public ChatMessageService(
            IChatMessageRepository chatMessageRepository, 
            IChatRepository chatRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _chatRepository = chatRepository;
        }

        public async Task<IEnumerable<Message>> GetLatestChatMessages(int chatId, int offset, int count)
        {
            var exists = await _chatRepository.ExistsAsync(chatId);
            if (!exists)
                throw new HttpRequestException(
                    "Chat doesn't exist",
                    null, System.Net.HttpStatusCode.NotFound);

            var result = await _chatMessageRepository.GetLatestChatMessages(chatId, offset, count);
            var users = result.Select(x => Message.FromEntity(x)).ToList();

            return users;
        }
    }
}
