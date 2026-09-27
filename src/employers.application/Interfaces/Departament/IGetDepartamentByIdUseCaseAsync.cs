using System.Threading.Tasks;
using employers.domain.Entities.Departament;

namespace employers.application.Interfaces.Departament;

public interface IGetDepartamentByIdUseCaseAsync
{
    Task<DepartmentEntity> RunAsync(int id);
}
