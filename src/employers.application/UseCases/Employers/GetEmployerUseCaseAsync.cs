using System.Collections.Generic;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Employers
{
    public class GetEmployerUseCaseAsync : IGetEmployerUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployerUseCaseAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeEntity>> RunAsync()
        {
            var result = await _unitOfWork.EmployerRepository.GetAll();

            return result;
        }
    }
}
