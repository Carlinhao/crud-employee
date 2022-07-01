using System.Linq;
using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Validators;

namespace employers.application.UseCases.Employers
{
    public class InsertEmployerUseCaseAsync : IInsertEmployerUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationMessages _notificationMessages;

        public InsertEmployerUseCaseAsync(INotificationMessages notificationMessages,
                                          IUnitOfWork unitOfWork)
        {
            _notificationMessages = notificationMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> RunAsync(EmployerRequest request)
        {
            request.Gender = char.ToUpper(request.Gender);

            var notification = UtilValidators.ValidadorResult(new EmployerRequestValidator(), request);

            if (notification.Errors.Count > 0)
            {
                foreach (var item in notification.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notificationMessages.AddNotification("InsertEmployerUseCaseAsync", item, HttpStatusCode.BadRequest);
                }

                return 0;
            }

            var result = await _unitOfWork.EmployerRepository.InsertAsync(request);
            _unitOfWork.Transaction();

            return result;
        }
    }
}
