using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using employers.domain.Interfaces.Repositories;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.infrastructure.Repositories.Departament;
using employers.infrastructure.Repositories.Employer;
using employers.infrastructure.Repositories.Occupation;
using employers.infrastructure.Repositories.UserAuth;

namespace employers.infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IEmployerRepository EmployerRepository { get; private set; }
        public IOccupationRepository OccupationRepository { get; private set; }
        public IUserAuthRepository UserAuthRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(IDbConnection connection,
                          IDbTransaction dbTransaction)
        {
            _connection = connection;
            _dbTransaction = dbTransaction;

            DepartmentRepository = new DepartmentRepository(_connection, _dbTransaction);
            EmployerRepository = new EmployerRepository(_connection, _dbTransaction);
            OccupationRepository = new OccupationRepository(_connection, _dbTransaction);
            UserAuthRepository = new UserAuthRepository(_connection, _dbTransaction);
            UserRepository = new UserRepository(_connection, _dbTransaction);
        }

        public void Dispose()
        {
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
