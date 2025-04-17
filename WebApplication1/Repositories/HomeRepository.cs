using System.Data;
using System.Data.SqlClient;
using MyMicroservice.Models;
using WebApplication1.Interfaces;
using Dapper;

namespace WebApplication1.Repositories
{
    public class HomeRepository(IConfiguration configuration) : IHomeRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");

     
        public async Task<Home[]> GetHomeAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spReadHome]";
                var parameters = new DynamicParameters();
                var sample = await connection.QueryAsync<Home>(sql, parameters, commandType: CommandType.StoredProcedure);
                return (Home[])sample.ToArray();
            }

        }
    }
}
