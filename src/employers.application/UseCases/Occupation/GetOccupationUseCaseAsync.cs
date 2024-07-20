using employers.application.Interfaces.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.application.UseCases.Occupation
{
    public class GetOccupationUseCaseAsync : IGetOccupationUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOccupationUseCaseAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultResponse> RunAsync()
        {
            return await _unitOfWork.OccupationRepository.GetAllAsync();
        }
    }
}
