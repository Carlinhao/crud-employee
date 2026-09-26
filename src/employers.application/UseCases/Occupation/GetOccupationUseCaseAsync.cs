using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.UseCases.Occupation;

public class GetOccupationUseCaseAsync(IUnitOfWork unitOfWork) : IGetOccupationUseCaseAsync
{
    public async Task<ResultResponse> RunAsync()
        => await unitOfWork.OccupationRepository.GetAllAsync();
}
