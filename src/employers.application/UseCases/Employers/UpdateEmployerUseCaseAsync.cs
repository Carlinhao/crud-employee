using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Responses;
using employers.domain.Validators;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class UpdateEmployerUseCaseAsync : IUpdateEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly INotificationMessages _notificationMessages;

        public UpdateEmployerUseCaseAsync(IEmployerRepository employerRepository,
                                          INotificationMessages notificationMessages)
        {
            _employerRepository = employerRepository;
            _notificationMessages = notificationMessages;
        }

        public async Task<ResultResponse> RunAsync(EmployeeEntity entity)
        {
            var employerValidator = UtilValidators.ValidadorResult(new EmployerEntityValidator(), entity);

            if(employerValidator.Errors.Count() > 0)
            {
                foreach (var item in employerValidator.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notificationMessages.AddNotification("UpdateEmployerUseCaseAsync", item, HttpStatusCode.BadRequest);

                }

                return new ResultResponse();
            }

            var result = await _employerRepository.UpdateAsync(entity);

            return result;
        }
    }
}
