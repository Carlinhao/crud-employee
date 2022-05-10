using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using employers.domain.Entities.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;

namespace employers.infrastructure.Repositories.UserAuth
{
    public class UserRepository : IUserRepository
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public UserRepository(IDbConnection connection,
                              IDbTransaction dbTransaction)
        {
            _stringBuilder = new StringBuilder();
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public Task<int> DisableUser(int id)
        {
            // TODO - Do get by id
            throw new NotImplementedException();
        }

        public async Task<int?> FindUser(string userName)
        {
            _stringBuilder.Append($"SELECT COUNT(1) FROM User_Auth WHERE NAME_USER = '{userName}'");
            var result = await _connection.QueryAsync<int>(_stringBuilder.ToString(), null, _dbTransaction);

            return result.FirstOrDefault();
        }

        public async Task<int> InsertUser(UserEntity userEntity)
        {
            _stringBuilder.Append($"INSERT INTO User_Auth ");
            _stringBuilder.Append($"VALUES ('{userEntity.UserName}', '{userEntity.FullName}', '{userEntity.Password}', '', '', '')");

            var result = await _connection.ExecuteAsync(_stringBuilder.ToString(), null, _dbTransaction);

            return result;
        }
    }
}
