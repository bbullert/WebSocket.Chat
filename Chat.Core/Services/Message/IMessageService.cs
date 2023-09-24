using Chat.Core.Dto;

namespace Chat.Core.Services
{
    public interface IMessageService
    {
        Task<int> CreateAsync(MessageCreate user);
        Task<Message> GetAsync(int id);
    }
}