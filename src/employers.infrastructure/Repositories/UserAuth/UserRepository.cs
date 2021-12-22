using Dapper;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.UserAuth
{
    public class UserRepository : IUserRepository
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _stringBuilder = new StringBuilder();
            _connection = connection;
        }

        public Task<bool> DisableUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertUser(UserEntity userEntity)
        {
            _stringBuilder.Append($"INSERT INTO User_Auth ");
            _stringBuilder.Append($"VALUES ('{userEntity.UserName}', '{userEntity.FullName}', '{userEntity.Password}', '', '', '')");

            var result = await _connection.ExecuteAsync(_stringBuilder.ToString());

            return result;
        }
    }
}
