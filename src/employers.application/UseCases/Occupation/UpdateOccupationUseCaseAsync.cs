using System.Threading.Tasks;
using employers.application.Interfaces.Occupation;
using employers.application.Notifications;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Responses;
using employers.domain.Validators;
using System.Linq;
using System.Net;

namespace employers.application.UseCases.Occupation
{
    public class UpdateOccupationUseCaseAsync : IUpdateOccupationUseCaseAsync
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationMessages _notification;

        public UpdateOccupationUseCaseAsync(IUnitOfWork unitOfWork,
                                            INotificationMessages notification)
        {
            _unitOfWork = unitOfWork;
            _notification = notification;
        }

        public async Task<ResultResponse> RunAsync(OccupationUpdateRequest request)
        {
            var erros = UtilValidators.ValidadorResult(new OccupationUpdateRequestValidator(), request);

            if (erros.Errors.Count > 0)
            {
                foreach (var item in erros.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notification.AddNotification("", item, HttpStatusCode.BadRequest);
                }

                return null;
            }

            var result = await _unitOfWork.OccupationRepository.UpdateAsync(request);
            _unitOfWork.Transaction();

            return result;
        }
    }
}
