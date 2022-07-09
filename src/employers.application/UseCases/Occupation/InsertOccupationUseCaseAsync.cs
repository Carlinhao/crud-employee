using System.Linq;
using System.Net;
using System.Threading.Tasks;
using employers.application.Interfaces.Occupation;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Responses;
using employers.domain.Validators;

namespace employers.application.UseCases.Occupation
{
    public class InsertOccupationUseCaseAsync : IInsertOccupationUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationMessages _notificationMessages;
        public InsertOccupationUseCaseAsync(IUnitOfWork unitOfWork, 
                                            INotificationMessages notificationMessages)
        {
            _unitOfWork = unitOfWork;
            _notificationMessages = notificationMessages;
        }

        public async Task<ResultResponse> RunAsync(OccupationRequest request)
        {
            var error = UtilValidators.ValidadorResult(new OccupationRequestValidator(), request);

            if (error.Errors.Count > 0 )
            {
                foreach (var item in error.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notificationMessages.AddNotification("InsertOccupationUseCaseAsync", item, HttpStatusCode.BadRequest);
                }

                return null;
            }

            var result = await _unitOfWork.OccupationRepository.InsertAsync(request);
            _unitOfWork.Transaction();

            return result;
        }
    }
}
