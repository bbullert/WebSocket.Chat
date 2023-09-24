namespace Chat.Data.Repositories
{
    public interface IChatRepository
    {
        Task<int> CreateAsync(Data.Entities.Chat entity);
        Task<IEnumerable<Entities.Chat>> GetAllAsync();
        Task<Entities.Chat> GetAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}