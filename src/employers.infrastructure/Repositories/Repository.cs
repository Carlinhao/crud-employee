using System.Collections.Generic;
using System.Threading.Tasks;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;

namespace employers.infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Task<int?> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int?> InsertAsync(TEntity request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultResponse> UpdateAsync(TEntity request)
        {
            throw new System.NotImplementedException();
        }
    }
}
