using Chat.Data.Entities;
using Chat.Data.Resources.User;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Chat.Data.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<User> GetAsync(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { id };
                var result = await connection.QueryAsync<User>(Sql.Get, param);
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(Sql.GetAll);
                return result.ToList();
            }
        }

        public async Task<int> CreateAsync(User entity)
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
                            entity.FirstName,
                            entity.LastName,
                            entity.Avatar
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
