using System.Net;
using System.Threading.Tasks;
using employers.application.Notifications;
using employers.application.UseCases.Departament;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using Moq;
using Xunit;

namespace employer.application.tests.UseCases.Department
{
    public class InsertDepartmentUseCaseAsyncTest
    {
        private readonly Mock<INotificationMessages> _notificationMessages;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public InsertDepartmentUseCaseAsyncTest()
        {
            _notificationMessages = new Mock<INotificationMessages>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact(DisplayName = "Insert Department Success")]
        [Trait("Category", "Department")]
        public async Task InsertDepartmentUseCaseAsync_WhenDataIsValid_MustInsertDepartment()
        {
            // Arrange
            var useCase = GetInsertUseCase();
            var request = GetDepartmentRequest();

            // Act
            _unitOfWork.Setup(x => x.DepartmentRepository.InsertAsync(request)).ReturnsAsync(1);
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
            return new InsertDepartmentUseCaseAsync(_notificationMessages.Object,
                                                    _unitOfWork.Object);
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
