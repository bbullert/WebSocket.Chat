using Chat.Data.Entities;
using Chat.Data.Resources.ChatMessage;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Chat.Data.Repositories
{
    public class ChatMessageRepository : Repository, IChatMessageRepository
    {
        public ChatMessageRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Message>> GetLatestChatMessages(int chatId, int offset, int count)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new
                {
                    chatId,
                    offset,
                    count
                };
                var result = await connection.QueryAsync<Message>(Sql.GetLatestChatMessages, param);
                return result.ToList();
            }
        }
    }
}
