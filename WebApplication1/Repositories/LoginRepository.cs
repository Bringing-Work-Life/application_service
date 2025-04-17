using System.Data;
using System.Data.SqlClient;
using MyMicroservice.Models;
using WebApplication1.Interfaces;
using Dapper;
using Microsoft.VisualBasic;
using System.Numerics;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.Common;

namespace WebApplication1.Repositories
{
    public class LoginRepository(IConfiguration configuration) : ILoginRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");


        public async Task<LoginResponseDto> GetUserAsync(LoginRequest loginRequest)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spGetUser]";
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", loginRequest.UserName, DbType.String);
                parameters.Add("@Password", loginRequest.Password, DbType.String);
                
                try
                {
                    var newUserId = await connection.QuerySingleAsync<LoginResponseDto>(sql, parameters, commandType: CommandType.StoredProcedure);

                    return newUserId;
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions, including custom errors
                    if (ex.Number == 50000) // Custom error number for duplicate UserName
                    {
                        // Handle duplicate username error
                    }
                    throw;
                }
            }
        }

    }
}
