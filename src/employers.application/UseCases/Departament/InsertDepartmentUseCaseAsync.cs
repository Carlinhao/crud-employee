using employers.application.Interfaces.Departament;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class InsertDepartmentUseCaseAsync : IInsertDepartmentUseCaseAsync
    {
        private readonly IDepartmentRepository _departamentRepository;

        public InsertDepartmentUseCaseAsync(IDepartmentRepository departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }

        public async Task<int?> RunAsync(DepartmentRequest departmentRequest)
        {
            var result = await _departamentRepository.InsertAsync(departmentRequest);

            return result;
        }
    }
}
