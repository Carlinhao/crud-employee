using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.UserAuth;
using static Dapper.SqlMapper;

namespace employers.infrastructure.Repositories.UserAuth
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public UserAuthRepository(IDbConnection connection,
                                  IDbTransaction transaction)
        {
            _connection = connection;
            _stringBuilder = new StringBuilder();
            _transaction = transaction;
        }

        public async Task<UserEntity> ValidateCredentials(UserInfoRequest userInfoRequest)
        {
            var password = ComputeHash(userInfoRequest.Password, new HMACMD5());
            var query = $" SELECT * FROM User_Auth WHERE NAME_USER = '{ userInfoRequest.UserName }' AND USER_PWD = '{ password }'";
            var result = await _connection.QueryFirstAsync<UserEntity>(query, null, _transaction);

            return result;
        }

        public async Task<UserEntity> ValidateCredentials(string userName)
        {
            var query = $" SELECT * FROM User_Auth WHERE NAME_USER = '{ userName }' ";
            var result = await _connection.QueryFirstAsync<UserEntity>(query, null, _transaction);

            return result;
        }

        public async Task RefresUserInfo(UserEntity request)
        {
            var user = await GetIdByUserName(request);
            
            _stringBuilder.Append($"UPDATE User_Auth SET NAME_USER = '{request.UserName}', ");
            _stringBuilder.Append($"USER_PWD = '{request.Password}', ");
            _stringBuilder.Append($"ACESS_TOKEN = '{request.AcessToken}', ");
            _stringBuilder.Append($"REFRESH_TOKEN = '{request.RefreshToken}', ");
            _stringBuilder.Append($"REFRESH_TOKEN_EXPIRE = '{request.RefreshTokenExpire}' ");
            _stringBuilder.Append($"WHERE ID_USER = {user.Id}");

            await _connection.QueryAsync<UserEntity>(_stringBuilder.ToString(), null, _transaction);
        }

        private async Task<UserEntity> GetIdByUserName(UserEntity request)
        {
            var query = $" SELECT * FROM User_Auth WHERE NAME_USER = '{ request.UserName }'";
            var result = await _connection.QueryFirstAsync<UserEntity>(query, null, _transaction);

            return result;
        }

        public string ComputeHash(string input, HMACMD5 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes);
        }
    }
}
