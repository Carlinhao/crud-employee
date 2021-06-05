using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.UseCases.Occupation
{
    public class InsertOccupationUseCaseAsync : IInsertOccupationUseCaseAsync
    {
        private readonly IOccupationRepository _occupationRepository;

        public InsertOccupationUseCaseAsync(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<ResultResponse> RunAsync(OccupationRequest request)
        {
            return await _occupationRepository.InsertAsync(request);
        }
    }
}
