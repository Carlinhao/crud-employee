using employers.api.Controllers;
using employers.application.Interfaces.Departament;
using employers.application.Interfaces.UseCases.Departament;
using employers.application.Notifications;
using employers.domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace employer.api.tests.Controllers
{
    public class DepartmentControllerTest
    {
        private readonly Mock<ILogger<DepartmentController>> _logger;
        private readonly Mock<INotificationMessages> _notificationMessages;
        private readonly Mock<IGetDepartamentUseCaseAsync> _useCaseAsync;
        private readonly Mock<IGetDepartamentByIdUseCaseAsync> _useByIdCaseAsync;

        public DepartmentControllerTest()
        {
            _logger = new Mock<ILogger<DepartmentController>>();
            _notificationMessages = new Mock<INotificationMessages>();
            _useCaseAsync = new Mock<IGetDepartamentUseCaseAsync>();
            _useByIdCaseAsync = new Mock<IGetDepartamentByIdUseCaseAsync>();
        }

        [Fact(DisplayName = "Test method Get Department")]
        [Trait("Category", "DepartmentController")]
        public async Task DepartmentController_WhenDataIsValid_MethodGetMustReturnAllDepartment()
        {
            // Arrange
            var departmentController = GetDepartmentController();
            var response = GetDepartmentEntity();
            _useCaseAsync.Setup(x => x.RunAsync()).ReturnsAsync(response);
            var result = await departmentController.GetAll(_useCaseAsync.Object);

            // Act
            var objcetResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var objectResponse = objcetResult.Value.Should().BeAssignableTo<IEnumerable<DepartmentEntity>>().Subject;

            // Assert
            Assert.Collection(objectResponse,
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(2, item.Id),
                item => Assert.Equal(3, item.Id));
        }

        [Fact(DisplayName = "Test method GetById Department")]
        [Trait("Category", "DepartmentController")]
        public async Task DepartmentController_WhenIUseId_MustReturnDepartment()
        {
            // Arrange
            var departmentController = GetDepartmentController();

            var response = new DepartmentEntity() { Id = 1, Name = "Business" };
            _useByIdCaseAsync.Setup(x => x.RunAsync(1)).ReturnsAsync(response);
            var getById = await departmentController.GetById(_useByIdCaseAsync.Object, 1);

            // Act
            var objectResult = getById.Should().BeOfType<OkObjectResult>().Subject;
            var objectResponse = objectResult.Value.Should().BeAssignableTo<DepartmentEntity>().Subject;

            // Assert
            objectResponse.Should().Be(response, "Return correct object.");
        }


        [Fact(DisplayName = "Test method Get Department must return status code 204")]
        [Trait("Category", "DepartmentController")]
        public async Task GetAll_WhenNotFoundData_MustReturnStatusCodes204()
        {
            // Arrange
            var controller = GetDepartmentController();
            IEnumerable<DepartmentEntity> departments = null;
            _useCaseAsync.Setup(x => x.RunAsync()).ReturnsAsync(departments);

            // Act
            var data = await controller.GetAll(_useCaseAsync.Object);
            var dataObjectResult = data.Should().BeOfType<NoContentResult>().Subject;

            // Assert
            Assert.Equal((int)HttpStatusCode.NoContent, dataObjectResult.StatusCode);
        }


        [Fact(DisplayName = "Validate status code 404")]
        [Trait("Category", "DepartmentController")]
        public async Task GetById__WhenNotFoundData_MustReturnStatusCodes204()
        {
            // Arrange
            var controller = GetDepartmentController();
            DepartmentEntity response = null;
            _useByIdCaseAsync.Setup(x => x.RunAsync(1)).ReturnsAsync(response);

            // Act
            var data = await controller.GetById(_useByIdCaseAsync.Object, 1);
            var dataObjectResult = data.Should().BeOfType<NotFoundObjectResult>().Subject;

            // Assert
            Assert.Equal((int)HttpStatusCode.NotFound, dataObjectResult.StatusCode);
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
