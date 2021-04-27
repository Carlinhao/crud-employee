using employers.domain.Entities.Employee;
using employers.domain.Responses;

namespace employers.application.Interfaces.Empregado
{
    public interface IUpdateEmployerUseCaseAsync : 
        IRestRequestAsync<ResultResponse, EmployeeEntity>
    {        
    }
}
