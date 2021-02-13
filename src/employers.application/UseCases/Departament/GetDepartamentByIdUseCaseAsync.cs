using employers.application.Interfaces.Departament;
using employers.application.Notifications;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using System.Net;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class GetDepartamentByIdUseCaseAsync : IGetDepartamentByIdUseCaseAsync
    {
        private readonly IDepartmentRepository _departamentRepository;
        private readonly INotificationMessages _notificationMessages;

        public GetDepartamentByIdUseCaseAsync(
            IDepartmentRepository departamentRepository,
            INotificationMessages notificationMessages)
        {
            _departamentRepository = departamentRepository;
            _notificationMessages = notificationMessages;
        }

        public async Task<DepartmentEntity> RunAsync(int id)
        {
            if (id <= 0)
            {
                _notificationMessages.AddNotification("GetDepartamentByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);
                return new DepartmentEntity();
            }

            var result = await _departamentRepository.GetById(id);

            return result;
        }
    }
}
