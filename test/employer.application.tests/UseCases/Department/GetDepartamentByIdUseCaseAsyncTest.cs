using employers.application.Notifications;
using employers.application.UseCases.Departament;
using employers.domain.Interfaces.Repositories;
using employers.domain.Interfaces.Repositories.Departament;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Department
{
    public class GetDepartamentByIdUseCaseAsyncTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public GetDepartamentByIdUseCaseAsyncTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationMessages = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Testing invalid Id")]
        [Trait("Category", "Department")]
        public async Task GetDepartamentByIdUseCaseAsync_WhenInvalidID_MustDisplayMessage()
        {
            // Arrange
            var useCase = new GetDepartamentByIdUseCaseAsync(_unitOfWork.Object, _notificationMessages.Object);

            // Act
            await useCase.RunAsync(0);

            // Assert
            _notificationMessages.Verify(x => x.AddNotification("GetDepartamentByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest), Times.Once);
        }
    }
}
