using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Empregado
{
    public interface IGetEmployerUseCaseAsync
    {
        Task<EmployerResponse> RunAsync();
    }
}
