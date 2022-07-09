using System.Threading.Tasks;
using employers.application.Notifications;
using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Responses;
using Moq;
using Xunit;

namespace employer.application.tests.UseCases.Occupation
{
    public class InsertOccupationUseCaseAsyncTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<INotificationMessages> _notifications;

        public InsertOccupationUseCaseAsyncTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _notifications = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Insert an Occupation")]
        [Trait("Categoria", "Occupation")]
        public async Task InsertOccupationUseCaseAsync_RunAsync_MustInsertAnOccupation()
        {
            // Arrange
            var request = GetOccupationRequest();
            var response = GetResultResponse();
            var useCase = new InsertOccupationUseCaseAsync(_unitOfWork.Object, _notifications.Object);
            _unitOfWork.Setup(x => x.OccupationRepository.InsertAsync(request)).ReturnsAsync(response);

            // Act
            var result = await useCase.RunAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result is ResultResponse);
        }

        private OccupationRequest GetOccupationRequest()
        {
            return new OccupationRequest { LevelOccupation = "Sr.", NameOccupation = "Developer" };
        }

        private ResultResponse GetResultResponse()
        {
            var data = GetOccupationRequest();

            return new ResultResponse { Data = data, Message = "Insert with success", Success = true };
        }
    }
}