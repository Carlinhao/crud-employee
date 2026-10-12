using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Employers;

public class DeleteEmployerUseCaseAsync(IUnitOfWork unitOfWork,
    INotificationMessages notification) : IDeleteEmployerUseCaseAsync
{
    public async Task<int?> RunAsync(int id)
    {
        if (id <= 0)
        {
            notification.AddNotification("DeleteEmployerUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);
            return 0;
        }

        var result = await unitOfWork.EmployerRepository.DeleteAsync(id);
        unitOfWork.Transaction();
        return result;
    }
}
