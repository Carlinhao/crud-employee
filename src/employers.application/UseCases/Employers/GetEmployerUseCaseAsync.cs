using employers.application.Interfaces.Empregado;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Responses;
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

        public Task<EmployerResponse> RunAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
