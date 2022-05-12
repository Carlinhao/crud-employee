using System.Threading.Tasks;
using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Responses;

namespace employers.application.UseCases.Occupation
{
    public class UpdateOccupationUseCaseAsync : IUpdateOccupationUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOccupationUseCaseAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultResponse> RunAsync(OccupationUpdateRequest request)
        {
            var result = await _unitOfWork.OccupationRepository.UpdateAsync(request);
            _unitOfWork.Transaction();

            return result;
        }
    }
}
