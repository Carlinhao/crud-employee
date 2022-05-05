using System;
using employers.domain.Interfaces.Repositories.Departament;

namespace employers.domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        void Transaction();
    }
}
