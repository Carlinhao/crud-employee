using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Departament;
using employers.application.Notifications;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Departament
{
    public class GetDepartamentByIdUseCaseAsync : IGetDepartamentByIdUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationMessages _notificationMessages;

        public GetDepartamentByIdUseCaseAsync(
            IUnitOfWork unitOfWork,
            INotificationMessages notificationMessages)
        {
            _unitOfWork = unitOfWork;
            _notificationMessages = notificationMessages;
        }

        public async Task<DepartmentEntity> RunAsync(int id)
        {
            if (id <= 0)
            {
                _notificationMessages.AddNotification("GetDepartamentByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);
                return new DepartmentEntity();
            }

            var result = await _unitOfWork.DepartmentRepository.GetById(id);

            return result;
        }
    }
}
