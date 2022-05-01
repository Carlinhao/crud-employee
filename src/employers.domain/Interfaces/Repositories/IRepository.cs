using System.Collections.Generic;
using System.Threading.Tasks;
using employers.domain.Responses;

namespace employers.domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<int?> InsertAsync(TEntity request);
        Task<int?> DeleteAsync(int id);
        Task<ResultResponse> UpdateAsync(TEntity request);
    }
}
