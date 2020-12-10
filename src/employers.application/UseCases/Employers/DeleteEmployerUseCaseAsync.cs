using employers.application.Interfaces.Empregado;
using employers.domain.Interfaces.Repositories.Employers;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class DeleteEmployerUseCaseAsync : IDeleteEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public DeleteEmployerUseCaseAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<int?> RunAsync(int id)
        {
            var result = await _employerRepository.DeleteAsync(id);
            
            return result;
        }
    }
}
