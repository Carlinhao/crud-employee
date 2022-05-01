using System;
using System.Data;
using System.Threading.Tasks;
using employers.domain.Interfaces.Repositories;

namespace employers.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _dbTransaction;
        
        public void Dispose() => _connection?.Dispose();

        public Task Transaction()
        {
            throw new NotImplementedException();
        }
    }
}
