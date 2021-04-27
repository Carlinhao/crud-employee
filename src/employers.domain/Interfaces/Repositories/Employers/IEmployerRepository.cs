using employers.domain.Entities.Employee;
using employers.domain.Requests;
using employers.domain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories.Employers
{
    public interface IEmployerRepository
    {
        Task<EmployeeEntity> GetById(object id);
        Task<IEnumerable<EmployeeEntity>> GetAll();
        Task<int?> InsertAsync(EmployerRequest employerRequest);
        Task<int?> DeleteAsync(int id);
        Task<ResultResponse> UpdateAsync(EmployeeEntity entity);
    }
}
