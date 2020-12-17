using employers.domain.Entities.Employer;
using employers.domain.Responses;

namespace employers.application.Interfaces.Empregado
{
    public interface IUpdateEmployerUseCaseAsync : 
        IRestRequestAsync<ResultResponse, EmployerEntity>
    {        
    }
}
