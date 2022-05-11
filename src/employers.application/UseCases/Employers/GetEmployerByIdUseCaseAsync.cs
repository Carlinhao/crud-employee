using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Employers
{
    public class GetEmployerByIdUseCaseAsync : IGetEmployerByIdUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationMessages _notification;

        public GetEmployerByIdUseCaseAsync(INotificationMessages notification,
                                           IUnitOfWork unitOfWork)
        {
            _notification = notification;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeEntity> RunAsync(int id)
        {
            if (id <= 0)
            {
                _notification.AddNotification("GetEmployerByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);

                return new EmployeeEntity();
            }

            var result = await _unitOfWork.EmployerRepository.GetById(id);

            return result;
        }
    }
}
