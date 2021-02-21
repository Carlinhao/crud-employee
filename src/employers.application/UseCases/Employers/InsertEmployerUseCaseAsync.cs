using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using employers.domain.Validators;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class InsertEmployerUseCaseAsync : IInsertEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly INotificationMessages _notificationMessages;

        public InsertEmployerUseCaseAsync(IEmployerRepository employerRepository,
                                          INotificationMessages notificationMessages)
        {
            _employerRepository = employerRepository;
            _notificationMessages = notificationMessages;
        }

        public async Task<int?> RunAsync(EmployerRequest request)
        {
            var notification = UtilValidators.ValidadorResult(new EmployerRequestValidator(), request);

            if (notification.Errors.Count() > 0)
            {
                foreach (var item in notification.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notificationMessages.AddNotification("InsertEmployerUseCaseAsync", item, HttpStatusCode.BadRequest);
                }

                return 0;
            }

            var result = await _employerRepository.InsertAsync(request);

            return result;
        }
    }
}
