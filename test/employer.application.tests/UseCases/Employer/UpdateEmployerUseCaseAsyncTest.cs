using System.Net;
using System.Threading.Tasks;
using employers.application.Notifications;
using employers.application.UseCases.Employers;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using FluentAssertions;
using Moq;
using Xunit;


namespace employer.application.tests.UseCases.Employer
{
    public class UpdateEmployerUseCaseAsyncTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public UpdateEmployerUseCaseAsyncTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationMessages = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Must update Employer")]
        [Trait("Category", "Employer")]
        public async Task UpdateEmployerUseCaseAsync_WhenDataIsValid_MustUpdateEmployer()
        {
            // Arrange
            var useCase = UpdateEmployerUseCase();
            var request = GetEmployerEntity();
            var response = GetResponse();

            // Act
            _unitOfWork.Setup(x => x.EmployerRepository.UpdateAsync(request)).ReturnsAsync(response);

            var result = await useCase.RunAsync(request);

            // Assert
            Assert.NotNull(result);
            result.Message.Should().NotBeEmpty().And.Contain("Update employer success", "Because update employer with success");
        }

        [Fact(DisplayName = "Must return notification when request is invalid")]
        [Trait("Category", "Employer")]
        public async Task UpdateEmployerUseCaseAsync_WhenDataIsInvalid_MustReturnNotification()
        {
            // Arrange
            var useCase = UpdateEmployerUseCase();
            var request = new EmployeeEntity();

            // Act
            await useCase.RunAsync(request);

            // Assert
            _notificationMessages.Verify(x => x.AddNotification("UpdateEmployerUseCaseAsync", It.IsAny<string>(), HttpStatusCode.BadRequest), Times.Exactly(5));
        }

        private UpdateEmployerUseCaseAsync UpdateEmployerUseCase()
        {
            return new UpdateEmployerUseCaseAsync(_notificationMessages.Object, _unitOfWork.Object);
        }

        private EmployeeEntity GetEmployerEntity()
        {
            return new EmployeeEntity
            {
                Id = 1,
                IdDepartament = 7,
                Name = "Paul Stone",
                Active = true,
                Gender = 'M',
                IdOccupation = 2
            };
        }

        private ResultResponse GetResponse()
        {
            var data = GetEmployerEntity();

            return new ResultResponse { Data = data, Message = "Update employer success", Success = true };
        }
    }
}
