using System;
using System.Data;
using employers.domain.Interfaces.Repositories;
using employers.domain.Interfaces.Repositories.Departament;
using employers.infrastructure.Repositories.Departament;

namespace employers.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public IDepartmentRepository DepartmentRepository { get; private set; }

        public UnitOfWork(IDbConnection connection,
                          IDbTransaction dbTransaction)
        {
            _connection = connection;
            _dbTransaction = dbTransaction;

            DepartmentRepository = new DepartmentRepository(_connection, _dbTransaction);
        }

        public void Dispose()
        {
            //_dbTransaction?.Rollback();
            _connection?.Dispose();
            _dbTransaction?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Transaction()
        {
            _dbTransaction.Commit();
        }
    }
}
