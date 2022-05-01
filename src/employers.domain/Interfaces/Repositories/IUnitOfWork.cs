using System;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task Transaction();
    }
}
