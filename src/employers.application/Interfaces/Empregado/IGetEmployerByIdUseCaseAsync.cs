using employers.domain.Entities.Employer;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Empregado
{
    public interface IGetEmployerByIdUseCaseAsync
    {
        Task<EmployerEntity> RunAsync(int id);
    }
}
