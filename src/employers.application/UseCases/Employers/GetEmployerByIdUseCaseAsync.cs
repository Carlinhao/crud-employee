using employers.application.Exceptions.RegraNegocio;
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
            if (id <= 0)
                throw new RegranegocioException("Invalid ID!");

            var result = await _employerRepository.GetById(id);

            return result;
        }
    }
}
