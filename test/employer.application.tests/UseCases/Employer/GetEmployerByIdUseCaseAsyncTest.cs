using System.Net;
using System.Threading.Tasks;
using employers.application.Notifications;
using employers.application.UseCases.Employers;
using employers.domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace employer.application.tests.UseCases.Employer
{
    public class GetEmployerByIdUseCaseAsyncTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<INotificationMessages> _notification;

        public GetEmployerByIdUseCaseAsyncTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _notification = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Testing invalid Id")]
        [Trait("Category", "Employer")]
        public async Task GetEmployerByIdUseCaseAsync_WhenInvalidID_MustDisplayMessage()
        {
            // Arrange 
            var useCase = new GetEmployerByIdUseCaseAsync(_notification.Object, _unitOfWork.Object);

            // Act
            await useCase.RunAsync(0);

            // Assert
            _notification.Verify(x => x.AddNotification("GetEmployerByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest), Times.Once);
        }
    }
}
