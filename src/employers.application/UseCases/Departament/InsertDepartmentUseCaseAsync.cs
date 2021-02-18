using employers.application.Interfaces.Departament;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using employers.domain.Validators;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class InsertDepartmentUseCaseAsync : IInsertDepartmentUseCaseAsync
    {
        private readonly IDepartmentRepository _departamentRepository;
        private readonly INotificationMessages _notificationMessages;

        public InsertDepartmentUseCaseAsync(IDepartmentRepository departamentRepository,
                                            INotificationMessages notificationMessages)
        {
            _departamentRepository = departamentRepository;
            _notificationMessages = notificationMessages;
        }

        public async Task<int?> RunAsync(DepartmentRequest departmentRequest)
        {
            var error = UtilValidators.ValidadorResult(new DepartmentRequestValidator(), departmentRequest);

            if (error.Errors.Count() > 0)
            {
                foreach (var item in error.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notificationMessages.AddNotification("InsertDepartmentUseCaseAsync", item, HttpStatusCode.BadRequest);

                }

                return 0;
            }

            var result = await _departamentRepository.InsertAsync(departmentRequest);

            return result;
        }
    }
}
