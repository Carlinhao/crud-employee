using System.Linq;
using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Departament;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Validators;

namespace employers.application.UseCases.Departament
{
    public class InsertDepartmentUseCaseAsync : IInsertDepartmentUseCaseAsync
    {
        private readonly INotificationMessages _notificationMessages;
        private readonly IUnitOfWork _unitOfWork;

        public InsertDepartmentUseCaseAsync(INotificationMessages notificationMessages,
                                            IUnitOfWork unitOfWork)
        {
            _notificationMessages = notificationMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> RunAsync(DepartmentRequest departmentRequest)
        {
            var error = UtilValidators.ValidadorResult(new DepartmentRequestValidator(), departmentRequest);

            if (error.Errors.Count > 0)
            {
                foreach (var item in error.Errors.Select(x => x.ErrorMessage).Distinct())
                {
                    _notificationMessages.AddNotification("InsertDepartmentUseCaseAsync", item, HttpStatusCode.BadRequest);

                }

                return 0;
            }

            var result = await _unitOfWork.DepartmentRepository.InsertAsync(departmentRequest);
            _unitOfWork.Transaction();

            return result;
        }
    }
}
