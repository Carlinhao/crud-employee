using employers.application.Interfaces.Empregado;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class GetEmployerByIdUseCaseAsync : IGetEmployerByIdUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public GetEmployerByIdUseCaseAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<EmployerEntity> RunAsync(int id)
        {
            var result = await _employerRepository.GetById(id);

            return result;
        }
    }
}
