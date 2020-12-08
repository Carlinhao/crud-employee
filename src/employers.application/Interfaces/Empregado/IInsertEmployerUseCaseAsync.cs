using employers.domain.Requests;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Empregado
{
    public interface IInsertEmployerUseCaseAsync
    {
        Task<int?> RunAsync(EmployerRequest request);
    }
}
