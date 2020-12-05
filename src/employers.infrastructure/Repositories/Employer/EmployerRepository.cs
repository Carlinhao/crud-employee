using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.Employer
{
    public class EmployerRepository : IEmployerRepository
    {
        
        public Task<IEnumerable<EmployerEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<EmployerEntity> GetById(object id)
        {
            throw new System.NotImplementedException();
        }
    }
}
