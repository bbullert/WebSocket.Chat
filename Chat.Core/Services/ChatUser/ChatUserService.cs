using Chat.Core.Dto;
using Chat.Data.Repositories;

namespace Chat.Core.Services
{
    public partial class ChatUserService : IChatUserService
    {
        private readonly IChatUserRepository _chatUserRepository;

        public ChatUserService(
            IChatUserRepository chatUserRepository
            )
        {
            _chatUserRepository = chatUserRepository;
        }

        public async Task<ChatUser> GetAsync(int chatId, int userId)
        {
            var result = await _chatUserRepository.GetAsync(chatId, userId);
            if (result is null) return null;
            var user = ChatUser.FromEntity(result);

            return user;
        }

        public async Task<IEnumerable<ChatUser>> GetAllAsync()
        {
            var result = await _chatUserRepository.GetAllAsync();
            var users = result.Select(x => ChatUser.FromEntity(x)).ToList();

            return users;
        }

        public async Task<IEnumerable<Core.Dto.Chat>> GetUserChatsAsync(int userId)
        {
            var result = await _chatUserRepository.GetUserChatsAsync(userId);
            var chats = result.Select(x => Core.Dto.Chat.FromEntity(x)).ToList();

            return chats;
        }

        public async Task<IEnumerable<User>> GetChatUsersAsync(int chatId)
        {
            var result = await _chatUserRepository.GetChatUsersAsync(chatId);
            var users = result.Select(x => User.FromEntity(x)).ToList();

            return users;
        }

        public async Task<int> CreateAsync(int chatId, int userId)
        {
            var result = await _chatUserRepository.ExistsAsync(chatId, userId);
            if (result)
                throw new HttpRequestException(
                    "User is already a member of this chat",
                    null, System.Net.HttpStatusCode.Conflict);

            var id = await _chatUserRepository.CreateAsync(chatId, userId);
            return id;
        }

        public bool Remove(int chatId, int userId)
        {
            return _chatUserRepository.Remove(chatId, userId);
        }
    }
}
