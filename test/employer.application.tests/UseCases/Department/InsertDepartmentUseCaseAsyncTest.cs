using employers.application.Notifications;
using employers.application.UseCases.Departament;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Department
{
    public class InsertDepartmentUseCaseAsyncTest
    {
        private readonly Mock<IDepartmentRepository> _departmentRepository;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public InsertDepartmentUseCaseAsyncTest()
        {
            _departmentRepository = new Mock<IDepartmentRepository>();
            _notificationMessages = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Insert Department Success")]
        [Trait("Category", "Department")]
        public async Task InsertDepartmentUseCaseAsync_WhenDataIsValid_MustInsertDepartment()
        {
            // Arrange
            var useCase = GetInsertUseCase();
            var request = GetDepartmentRequest();

            // Act
            _departmentRepository.Setup(x => x.InsertAsync(request)).ReturnsAsync(1);
            var result = await useCase.RunAsync(request);

            // Assert
            Assert.Equal(1, result.Value);
        }

        [Theory(DisplayName = "Insert Department Success")]
        [Trait("Category", "Department")]
        [InlineData("")]
        [InlineData(null)]
        public async Task InsertDepartmentUseCaseAsync_WhenDataNotValid_MustReturnNotification(string departmentRequest)
        {
            // Arrange
            var useCase = GetInsertUseCase();
            var request = new DepartmentRequest() { Name = departmentRequest, Manager = 987, Description = "Test Department" };

            // Act
            var result = await useCase.RunAsync(request);

            // Assert
            _notificationMessages.Verify(x => x.AddNotification("InsertDepartmentUseCaseAsync", It.IsAny<string>(), HttpStatusCode.BadRequest), Times.Once);
        }


        private InsertDepartmentUseCaseAsync GetInsertUseCase()
        {
            return new InsertDepartmentUseCaseAsync(_departmentRepository.Object,
                                                    _notificationMessages.Object);
        }

        private DepartmentRequest GetDepartmentRequest()
        {
            return new DepartmentRequest
            {
                Name = "IT",
                Manager = 987,
                Description = "Information Tecnology"
            };
        }
    }
}
