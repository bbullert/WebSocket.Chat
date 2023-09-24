using Chat.Data.Entities;

namespace Chat.Data.Repositories
{
    public interface IMessageRepository
    {
        Task<int> CreateAsync(Message entity);
        Task<Message> GetAsync(int id);
    }
}