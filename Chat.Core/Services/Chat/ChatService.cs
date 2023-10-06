using Chat.Core.Dto;
using Chat.Data.Repositories;

namespace Chat.Core.Services
{
    public partial class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(
            IChatRepository chatRepository
            )
        {
            _chatRepository = chatRepository;
        }

        public async Task<Dto.Chat> GetAsync(int id)
        {
            var result = await _chatRepository.GetAsync(id);
            if (result == null) return null;
            var user = Dto.Chat.FromEntity(result);

            return user;
        }

        public async Task<IEnumerable<Dto.Chat>> GetAllAsync()
        {
            var result = await _chatRepository.GetAllAsync();
            var users = result.Select(x => Dto.Chat.FromEntity(x)).ToList();

            return users;
        }

        public async Task<int> CreateAsync(ChatCreate user)
        {
            var id = await _chatRepository.CreateAsync(user.ToEntity());
            return id;
        }
    }
}
