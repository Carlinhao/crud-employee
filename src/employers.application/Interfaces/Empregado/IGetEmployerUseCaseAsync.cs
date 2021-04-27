using employers.domain.Entities.Employer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Empregado
{
    public interface IGetEmployerUseCaseAsync
    {
        Task<IEnumerable<EmployeeEntity>> RunAsync();
    }
}
