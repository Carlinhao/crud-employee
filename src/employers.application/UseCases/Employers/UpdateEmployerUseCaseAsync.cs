using employers.application.Interfaces.Empregado;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class UpdateEmployerUseCaseAsync : IUpdateEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public UpdateEmployerUseCaseAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<ResultResponse> RunAsync(EmployerEntity entity)
        {
            var result = await _employerRepository.UpdateAsync(entity);

            return result;
        }
    }
}
