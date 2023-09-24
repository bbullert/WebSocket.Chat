using Chat.Core.Dto;
using Chat.Data.Repositories;

namespace Chat.Core.Services
{
    public partial class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> GetAsync(int id)
        {
            var result = await _messageRepository.GetAsync(id);
            if (result == null) return null;
            var user = Message.FromEntity(result);

            return user;
        }

        public async Task<int> CreateAsync(MessageCreate user)
        {
            var id = await _messageRepository.CreateAsync(user.ToEntity());
            return id;
        }
    }
}
