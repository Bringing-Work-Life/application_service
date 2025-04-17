using System.Data;
using System.Data.SqlClient;
using MyMicroservice.Models;
using WebApplication1.Interfaces;
using Dapper;

namespace WebApplication1.Repositories
{
    public class SampleRepository(IConfiguration configuration) : ISampleRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");

        public async Task<int> CreateSampleAsync(Sample sample)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spCreateSample]";
                var parameters = new DynamicParameters();
                parameters.Add("@Name", sample.Name, DbType.String);
                parameters.Add("@Description", sample.Description, DbType.String);

                var id = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
        }

        public async Task<Sample> GetSampleAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spReadSample]";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);

                var sample = await connection.QuerySingleOrDefaultAsync<Sample>(sql, parameters, commandType: CommandType.StoredProcedure);
                return sample;
            }
        }

        public async Task<bool> UpdateSampleAsync(Sample sample)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spUpdateSample]";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", sample.Id, DbType.Int32);
                parameters.Add("@Name", sample.Name, DbType.String);
                parameters.Add("@Description", sample.Description, DbType.String);

                var affectedRows = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteSampleAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spDeleteSample]";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }
    }
}
