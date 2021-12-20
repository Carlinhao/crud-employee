using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.UserAuth;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace employers.infrastructure.Repositories.UserAuth
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly IConfiguration _configuration;
        private StringBuilder _stringBuilder;
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
            _stringBuilder = new StringBuilder();
        }
        
        public async Task<UserEntity> ValidateCredentials(UserInfoRequest userInfoRequest)
        {
            var password = ComputeHash(userInfoRequest.Password, new SHA256CryptoServiceProvider());

            var query = $" SELECT * FROM User_Auth WHERE NAME_USER = '{ userInfoRequest.UserName }' AND USER_PWD = '{ password }'";

            using IDbConnection conn = Connection;
            conn.Open();

            var result = await conn.QueryFirstAsync<UserEntity>(query);

            return result;
        }

        public async Task<UserEntity> ValidateCredentials(string userName)
        {
            var query = $" SELECT * FROM User_Auth WHERE NAME_USER = '{ userName }' ";

            using IDbConnection conn = Connection;
            conn.Open();

            var result = await conn.QueryFirstAsync<UserEntity>(query);

            return result;
        }

        public async Task RefresUserInfo(UserEntity request)
        {
            var user = await GetIdByUserName(request);
            
            using IDbConnection conn = Connection;
            conn.Open();

            _stringBuilder.Append($"UPDATE User_Auth SET NAME_USER = '{request.UserName}', ");
            _stringBuilder.Append($"USER_PWD = '{request.Password}', ");
            _stringBuilder.Append($"ACESS_TOKEN = '{request.AcessToken}', ");
            _stringBuilder.Append($"REFRESH_TOKEN = '{request.RefreshToken}', ");
            _stringBuilder.Append($"REFRESH_TOKEN_EXPIRE = '{request.RefreshTokenExpire}' ");
            _stringBuilder.Append($"WHERE ID_USER = {user.Id}");

            await conn.QueryAsync<UserEntity>(_stringBuilder.ToString());
        }

        private async Task<UserEntity> GetIdByUserName(UserEntity request)
        {
            var query = $" SELECT * FROM User_Auth WHERE NAME_USER = '{ request.UserName }'";

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
