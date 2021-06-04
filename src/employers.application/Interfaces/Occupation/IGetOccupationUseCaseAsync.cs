using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.Interfaces.Occupation
{
    public interface IGetOccupationUseCaseAsync
    {
        Task<ResultResponse> RunAsync();
    }
}
