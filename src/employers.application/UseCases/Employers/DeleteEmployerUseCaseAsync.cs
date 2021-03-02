using employers.application.Exceptions.RegraNegocio;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories.Employers;
using System.Net;
using System.Threading.Tasks;

namespace employers.application.UseCases.Employers
{
    public class DeleteEmployerUseCaseAsync : IDeleteEmployerUseCaseAsync
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly INotificationMessages _notification;
        public DeleteEmployerUseCaseAsync(IEmployerRepository employerRepository,
            INotificationMessages notification)
        {
            _employerRepository = employerRepository;
            _notification = notification;
        }

        public async Task<int?> RunAsync(int id)
        {
            if (id <= 0)
            {
                _notification.AddNotification("DeleteEmployerUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest);
                return 0;
            }

            var result = await _employerRepository.DeleteAsync(id);            
            return result;
        }
    }
}
