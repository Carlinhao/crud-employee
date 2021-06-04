using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.UseCases.Occupation
{
    public class GetOccupationUseCaseAsync : IGetOccupationUseCaseAsync
    {
        private readonly IOccupationRepository _occupationRepository;

        public GetOccupationUseCaseAsync(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<ResultResponse> RunAsync()
        {
            return await _occupationRepository.GetAllAsync();
        }
    }
}
