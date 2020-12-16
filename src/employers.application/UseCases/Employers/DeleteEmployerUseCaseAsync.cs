using employers.application.Exceptions.RegraNegocio;
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
            if (id <= 0)
                throw new RegranegocioException("Invalid ID!");

            var result = await _employerRepository.DeleteAsync(id);
            
            return result;
        }
    }
}
