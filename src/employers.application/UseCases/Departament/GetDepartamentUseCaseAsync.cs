using employers.application.Interfaces.UseCases.Departament;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories;
using employers.domain.Interfaces.Repositories.Departament;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class GetDepartamentUseCaseAsync : IGetDepartamentUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDepartamentUseCaseAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DepartmentEntity>> RunAsync()
        {
            var result = await _unitOfWork.DepartmentRepository.GetAll();

            return result;
        }
    }
}
