using System.Linq;
using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using employers.domain.Validators;

namespace employers.application.UseCases.Employers;

public class UpdateEmployerUseCaseAsync(INotificationMessages notificationMessages,
                                  IUnitOfWork unitOfWork) : IUpdateEmployerUseCaseAsync
{
    public async Task<ResultResponse> RunAsync(EmployeeEntity entity)
    {
        entity.Gender = char.ToUpper(entity.Gender);

        var employerValidator = UtilValidators.ValidadorResult(new EmployerEntityValidator(), entity);

        if(employerValidator.Errors.Count > 0)
        {
            foreach (var item in employerValidator.Errors.Select(x => x.ErrorMessage).Distinct())
            {
                notificationMessages.AddNotification("UpdateEmployerUseCaseAsync", item, HttpStatusCode.BadRequest);
            }

            return new ResultResponse();
        }

        var result = await unitOfWork.EmployerRepository.UpdateAsync(entity);
        unitOfWork.Transaction();

        return result;
    }
}
