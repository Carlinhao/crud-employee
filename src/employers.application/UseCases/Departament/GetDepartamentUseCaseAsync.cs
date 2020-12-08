using employers.application.Interfaces.UseCases.Departament;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class GetDepartamentUseCaseAsync : IGetDepartamentUseCaseAsync
    {
        private readonly IDepartmentRepository _departamentRepository;

        public GetDepartamentUseCaseAsync(IDepartmentRepository departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }

        public async Task<IEnumerable<DepartmentEntity>> RunAsync()
        {
            var result = await _departamentRepository.GetAll();

            return result;
        }
    }
}
