using Chat.Data.Entities;
using Chat.Data.Resources.ChatUser;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Chat.Data.Repositories
{
    public class ChatUserRepository : Repository, IChatUserRepository
    {
        public ChatUserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ChatUser> GetAsync(int chatId, int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { 
                    chatId, 
                    userId 
                };
                var result = await connection.QueryAsync<ChatUser>(Sql.Get, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> ExistsAsync(int chatId, int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new
                {
                    chatId,
                    userId
                };
                var result = await connection.QueryAsync<bool>(Sql.Exists, param);
                return result.First();
            }
        }

        public async Task<IEnumerable<ChatUser>> GetAllAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<ChatUser>(Sql.GetAll);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<Data.Entities.Chat>> GetUserChatsAsync(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { userId };
                var result = await connection.QueryAsync<Data.Entities.Chat>(Sql.GetUserChats, param);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<User>> GetChatUsersAsync(int chatId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { chatId };
                var result = await connection.QueryAsync<User>(Sql.GetChatUsers, param);
                return result.ToList();
            }
        }

        public async Task<int> CreateAsync(int chatId, int userId)
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
                            chatId,
                            userId
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

        public bool Remove(int chatId, int userId)
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
                            chatId,
                            userId
                        };
                        var result = connection.Query<int>(Sql.Remove, param, transaction);

                        transaction.Commit();
                        return result.First() != 0;
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
