using employers.domain.Entities;
using employers.domain.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories.Departament
{
    public interface IDepartmentRepository
    {
        Task<DepartmentEntity> GetById(object id);
        Task<IEnumerable<DepartmentEntity>> GetAll();
        Task<int?> InsertAsync(DepartmentRequest request);
    }
}
