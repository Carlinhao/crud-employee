using employers.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.Interfaces.UseCases.Departament
{
    public interface IGetDepartamentUseCaseAsync
    {
        Task<IEnumerable<DepartamentEntity>> RunAsync();
    }
}
