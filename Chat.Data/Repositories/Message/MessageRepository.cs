using Chat.Data.Entities;
using Chat.Data.Resources.Message;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Chat.Data.Repositories
{
    public class MessageRepository : Repository, IMessageRepository
    {
        public MessageRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Message> GetAsync(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { id };
                var result = await connection.QueryAsync<Message>(Sql.Get, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<int> CreateAsync(Message entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var param = new
                        {
                            entity.Content,
                            entity.CreateDate,
                            entity.UserId,
                            entity.ChatId
                        };
                        var result = await connection.QueryAsync<int>(Sql.Create, param, transaction);

                        transaction.Commit();
                        return result.FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
