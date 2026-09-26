using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Employers;

public class GetEmployerByIdUseCaseAsync(INotificationMessages notification,
                                   IUnitOfWork unitOfWork) : IGetEmployerByIdUseCaseAsync
{
    public async Task<EmployeeEntity> RunAsync(int id)
    {
        if (id <= 0)
        {
            notification.AddNotification("GetEmployerByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);

            return new EmployeeEntity();
        }

        var result = await unitOfWork.EmployerRepository.GetById(id);

        return result;
    }
}
