using employers.domain.Entities;
using employers.domain.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories.Departament
{
    public interface IDepartamentRepository
    {
        Task<DepartamentEntity> GetById(object id);
        Task<IEnumerable<DepartamentEntity>> GetAll();
        Task<int?> InsertAsync(DepartamentRequest request);
    }
}
