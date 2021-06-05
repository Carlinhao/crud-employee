using employers.domain.Requests;
using employers.domain.Responses;

namespace employers.application.Interfaces.Occupation
{
    public interface IInsertOccupationUseCaseAsync :
        IRestRequestAsync<ResultResponse, OccupationRequest>
    {
    }
}
