using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(object id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
