using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Employers
{
    public class DeleteEmployerUseCaseAsync : IDeleteEmployerUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationMessages _notification;
        public DeleteEmployerUseCaseAsync(IUnitOfWork unitOfWork,
            INotificationMessages notification)
        {
            _unitOfWork = unitOfWork;
            _notification = notification;
        }

        public async Task<int?> RunAsync(int id)
        {
            if (id <= 0)
            {
                _notification.AddNotification("DeleteEmployerUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);
                return 0;
            }

            var result = await _unitOfWork.EmployerRepository.DeleteAsync(id);
            _unitOfWork.Transaction();
            return result;
        }
    }
}
