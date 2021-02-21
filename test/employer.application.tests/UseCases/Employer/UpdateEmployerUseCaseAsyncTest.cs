using employers.application.Notifications;
using employers.application.UseCases.Employers;
using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Responses;
using Moq;
using System.Threading.Tasks;
using Xunit;


namespace employer.application.tests.UseCases.Employer
{
    public class UpdateEmployerUseCaseAsyncTest
    {
        private readonly Mock<IEmployerRepository> _employerRepository;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public UpdateEmployerUseCaseAsyncTest()
        {
            _employerRepository = new Mock<IEmployerRepository>();
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
            _employerRepository.Setup(x => x.UpdateAsync(request)).ReturnsAsync(response);

            var result = await useCase.RunAsync(request);

            // Assert
            Assert.NotNull(result);

        }

        private UpdateEmployerUseCaseAsync UpdateEmployerUseCase()
        {
            return new UpdateEmployerUseCaseAsync(_employerRepository.Object, _notificationMessages.Object);
        }

        private EmployerEntity GetEmployerEntity()
        {
            return new EmployerEntity
            {
                Id = 1,
                IdDepartament = 7,
                Name = "Business"
            };
        }

        private ResultResponse GetResponse()
        {
            var data = GetEmployerEntity();

            return new ResultResponse { Data = data, Message = "Update employer success", Success = true };
        }
    }
}
