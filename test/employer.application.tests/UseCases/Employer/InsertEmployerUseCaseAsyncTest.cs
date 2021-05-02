using employers.application.Notifications;
using employers.application.UseCases.Employers;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Employer
{
    public class InsertEmployerUseCaseAsyncTest
    {
        private readonly Mock<IEmployerRepository> _employerRepository;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public InsertEmployerUseCaseAsyncTest()
        {
            _employerRepository = new Mock<IEmployerRepository>();
            _notificationMessages = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Must insert Employer")]
        [Trait("Category", "Employer")]
        public async Task InsertEmployerUseCaseAsync_WhenDataIsValid_MustInsertEmployer()
        {
            // Arrange
            var useCase = InsertEmployerUseCase();
            var employerRequest = GetEmployer();
            _employerRepository.Setup(x => x.InsertAsync(employerRequest)).ReturnsAsync(1);

            // Act
            var result = await useCase.RunAsync(employerRequest);

            // Assert
            Assert.Equal(1, result);

        }

        [Fact(DisplayName = "Must return notification when data is not valid")]
        [Trait("Category", "Employer")]
        public async Task InsertEmployerUseCaseAsync_WhenDataIsNotValid_MustReturnNotification()
        {
            // Arrange
            var useCase = InsertEmployerUseCase();
            var employerRequest = new EmployerRequest();            

            // Act
            var result = await useCase.RunAsync(employerRequest);

            // Assert
            _notificationMessages.Verify(x => x.AddNotification("InsertEmployerUseCaseAsync", It.IsAny<string>(), HttpStatusCode.BadRequest), Times.Exactly(6));

        }

        private InsertEmployerUseCaseAsync InsertEmployerUseCase()
        {
            return new InsertEmployerUseCaseAsync(_employerRepository.Object, _notificationMessages.Object);
        }

        private EmployerRequest GetEmployer()
        {
            return new EmployerRequest
            {
                IdDepartment = 1,
                Name = "IT",
                Active = true,
                Gender = 'F',
                IdOccupation = 1
            };
        }
    }
}
