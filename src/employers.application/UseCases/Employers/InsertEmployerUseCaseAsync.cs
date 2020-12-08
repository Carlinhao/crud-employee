using employers.application.Interfaces.Empregado;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class InsertEmployerUseCaseAsync : IInsertEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public InsertEmployerUseCaseAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<int?> RunAsync(EmployerRequest request)
        {
            var result = await _employerRepository.InsertAsync(request);

            return result;
        }
    }
}
