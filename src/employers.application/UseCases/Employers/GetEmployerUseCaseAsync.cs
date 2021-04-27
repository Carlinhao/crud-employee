using employers.application.Interfaces.Empregado;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class GetEmployerUseCaseAsync : IGetEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public GetEmployerUseCaseAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<IEnumerable<EmployeeEntity>> RunAsync()
        {
            var result = await _employerRepository.GetAll();

            return result;
        }
    }
}
