using Dapper;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.UserAuth;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.UserAuth
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly IConfiguration _configuration;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("sqlConnect"));
            }
        }

        public UserAuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<UserEntity> ValidateCredentials(UserInfoRequest userInfoRequest)
        {
            var password = ComputeHash(userInfoRequest.Password, new SHA256CryptoServiceProvider());

            var query = $" SELECT * FROM Users WHERE USR_NAM = '{ userInfoRequest.UserName }' AND PWD = '{ password }'";

            using IDbConnection conn = Connection;
            conn.Open();

            var result = await conn.QueryFirstAsync<UserEntity>(query);

            return result;
        }

        public async Task<UserEntity> ValidateCredentials(string userName)
        {
            var query = $" SELECT * FROM Users WHERE USR_NAM = '{ userName }' ";

            using IDbConnection conn = Connection;
            conn.Open();

            var result = await conn.QueryFirstAsync<UserEntity>(query);

            return result;
        }

        public async Task<UserEntity> RefresUserInfo(UserEntity request)
        {
            var query = $" UPDATE Users WHERE Id = '{ request.Id }' " +
                $"SET USR_NAM = '{ request.FullName }', PWD = '{ request.Password }', RFH_TOK = '{ request.AcessToken }'" +
                $"RFH_TOK_EXP = '{ request.RefreshTokenExpire }' ";

            using IDbConnection conn = Connection;
            conn.Open();

            var result = await conn.QueryFirstAsync<UserEntity>(query);

            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes);
        }

    }
}
