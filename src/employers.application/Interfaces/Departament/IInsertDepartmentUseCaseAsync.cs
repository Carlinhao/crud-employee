using employers.domain.Requests;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Departament
{
    public interface IInsertDepartmentUseCaseAsync
    {
        Task<int?> RunAsync(DepartmentRequest departmentRequest);
    }
}
