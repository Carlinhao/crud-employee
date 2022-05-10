using System;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Interfaces.Repositories.UserAuth;

namespace employers.domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        IEmployerRepository EmployerRepository { get; }
        IOccupationRepository OccupationRepository { get; }
        IUserAuthRepository UserAuthRepository { get; }
        IUserRepository UserRepository { get; }
        void Transaction();
    }
}
