using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Departament;
using employers.application.Notifications;
using employers.domain.Entities.Departament;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Departament;

public class GetDepartamentByIdUseCaseAsync(
    IUnitOfWork unitOfWork,
    INotificationMessages notificationMessages) : IGetDepartamentByIdUseCaseAsync
{
    public async Task<DepartmentEntity> RunAsync(int id)
    {
        if (id <= 0)
        {
            notificationMessages.AddNotification("GetDepartamentByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);
            return new DepartmentEntity();
        }

        var result = await unitOfWork.DepartmentRepository.GetById(id);

        return result;
    }
}
