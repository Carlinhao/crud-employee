using employers.domain.Requests;
using employers.domain.Responses;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories.Occupation
{
    public interface IOccupationRepository
    {
        Task<ResultResponse> GetAllAsync();
        Task<ResultResponse> UpdateAsync(OccupationUpdateRequest request); 
        Task<ResultResponse> InsertAsync(OccupationRequest request);
    }
}
