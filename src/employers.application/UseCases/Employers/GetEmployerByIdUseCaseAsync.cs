using employers.application.Exceptions.RegraNegocio;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using System.Net;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class GetEmployerByIdUseCaseAsync : IGetEmployerByIdUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly INotificationMessages _notification;

        public GetEmployerByIdUseCaseAsync(IEmployerRepository employerRepository,
                                           INotificationMessages notification)
        {
            _employerRepository = employerRepository;
            _notification = notification;
        }

        public async Task<EmployerEntity> RunAsync(int id)
        {
            if (id <= 0)
            {
                _notification.AddNotification("GetEmployerByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);

                return new EmployerEntity();
            }

            var result = await _employerRepository.GetById(id);

            return result;
        }
    }
}
