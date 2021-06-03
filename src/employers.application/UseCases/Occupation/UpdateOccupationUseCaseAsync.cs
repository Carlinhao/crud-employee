using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.UseCases.Occupation
{
    public class UpdateOccupationUseCaseAsync : IUpdateOccupationUseCaseAsync
    {
        private readonly IOccupationRepository _occupationRepository;

        public UpdateOccupationUseCaseAsync(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<ResultResponse> RunAsync(OccupationUpdateRequest request)
        {
            var result = await _occupationRepository.UpdateAsync(request);

            return result;
        }
    }
}
