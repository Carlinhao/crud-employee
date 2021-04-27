using employers.domain.Entities.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Empregado
{
    public interface IGetEmployerUseCaseAsync
    {
        Task<IEnumerable<EmployeeEntity>> RunAsync();
    }
}
