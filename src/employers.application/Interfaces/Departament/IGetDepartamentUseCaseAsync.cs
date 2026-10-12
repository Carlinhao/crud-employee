using System.Collections.Generic;
using System.Threading.Tasks;
using employers.domain.Entities.Departament;

namespace employers.application.Interfaces.Departament;

public interface IGetDepartamentUseCaseAsync
{
    Task<IEnumerable<DepartmentEntity>> RunAsync();
}
