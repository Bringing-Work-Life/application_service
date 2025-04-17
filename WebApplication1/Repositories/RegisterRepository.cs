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
    public class RegisterRepository(IConfiguration configuration) : IRegisterRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");


        public async Task<Register> PostRegisterAsync(Register register)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "[dbo].[spCreateUser]";
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", register.FirstName, DbType.String);
                parameters.Add("@MiddleName", register.MiddleName, DbType.String);
                parameters.Add("@LastName", register.LastName, DbType.String);
                parameters.Add("@DOBDate", register.DOBDate, DbType.String);
                parameters.Add("@DOBTime", register.DOBTime, DbType.String);
                parameters.Add("@Phone", register.Phone, DbType.String);
                parameters.Add("@Street1", register.Street1, DbType.String);
                parameters.Add("@Street2", register.Street2, DbType.String);
                parameters.Add("@City", register.City, DbType.String);
                parameters.Add("@State", register.State, DbType.String);
                parameters.Add("@Pincode", register.Pincode, DbType.String);
                parameters.Add("@UserName", register.UserName, DbType.String);
                parameters.Add("@Password", register.Password, DbType.String);
                try
                {
                    var newUserId = await connection.QuerySingleAsync<Register>(sql, parameters, commandType: CommandType.StoredProcedure);

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
