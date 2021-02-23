using employers.api.Controllers;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.Notifications;
using employers.domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.Controllers
{
    public class DepartmentControllerTest
    {
        private readonly Mock<ILogger<DepartmentController>> _logger;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public DepartmentControllerTest()
        {
            _logger = new Mock<ILogger<DepartmentController>>();
            _notificationMessages = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Test method Get Department")]
        [Trait("Category", "Controller")]
        public async Task DepartmentController_WhenDataIsValid_MethodGetMustReturnAllDepartment()
        {
            // Arrange
            var departmentController = GetDepartmentController();
            Mock<IGetDepartamentUseCaseAsync> _useCaseAsync = new Mock<IGetDepartamentUseCaseAsync>();
            var response = GetDepartmentEntity();

            // Act
            _useCaseAsync.Setup(x => x.RunAsync()).ReturnsAsync(response);
            var result = await departmentController.GetAll(_useCaseAsync.Object);

            // Assert
            Assert.NotNull(result);
        }

        private DepartmentController GetDepartmentController()
        {
            return new DepartmentController(_logger.Object, _notificationMessages.Object);
        }

        private IEnumerable<DepartmentEntity> GetDepartmentEntity()
        {
            return new List<DepartmentEntity>
            {
                new DepartmentEntity
                {
                    Id = 1,
                    Name = "Business"
                },
                new DepartmentEntity
                {
                    Id = 2,
                    Name = "Sales"
                },
                new DepartmentEntity
                {
                    Id = 3,
                    Name = "Management"
                }
            };
        }
    }
}
