using Chat.Data.Resources.Chat;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Chat.Data.Repositories
{
    public class ChatRepository : Repository, IChatRepository
    {
        public ChatRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Data.Entities.Chat> GetAsync(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { id };
                var result = await connection.QueryAsync<Data.Entities.Chat>(Sql.Get, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { id };
                var result = await connection.QueryAsync<bool>(Sql.Exists, param);
                return result.First();
            }
        }

        public async Task<IEnumerable<Data.Entities.Chat>> GetAllAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Data.Entities.Chat>(Sql.GetAll);
                return result.ToList();
            }
        }

        public async Task<int> CreateAsync(Data.Entities.Chat entity)
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
                            entity.Name,
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
