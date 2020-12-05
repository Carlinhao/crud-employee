using employers.domain.Entities;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Departament
{
    public interface IGetDepartamentByIdUseCaseAsync
    {
        Task<DepartamentEntity> RunAsync(int id);
    }
}
