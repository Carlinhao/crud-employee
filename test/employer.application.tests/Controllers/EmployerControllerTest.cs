using employers.api.Controllers;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employer;
using employers.domain.Requests;
using employers.domain.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace employer.application.tests.Controllers
{
    public class EmployerControllerTest
    {
        private readonly Mock<ILogger<EmployerController>> _logger;
        private readonly Mock<INotificationMessages> _notificationMessages;

        public EmployerControllerTest()
        {
            _logger = new Mock<ILogger<EmployerController>>();
            _notificationMessages = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Test method Get Employer")]
        [Trait("Categoria", "EmployerController")]
        public async Task EmployerController_WhenDataIsValid_MethodGetMustReturnAllDepartment()
        {
            // Arrange
            var employerController = new EmployerController(_logger.Object, _notificationMessages.Object);
            Mock<IGetEmployerUseCaseAsync> useCase = new Mock<IGetEmployerUseCaseAsync>();
            var response = GetListEmployer();
            useCase.Setup(x => x.RunAsync()).ReturnsAsync(response);
            var result = await employerController.GetAll(useCase.Object);

            // Act
            var objectResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var objectResponse = objectResult.Value.Should().BeAssignableTo<IEnumerable<EmployerEntity>>().Subject;

            // Assert
            Assert.NotNull(objectResponse);
            Assert.Collection(objectResponse,
                item => Assert.Equal("TI", item.Name),
                item => Assert.Equal("Business", item.Name),
                item => Assert.Equal("Management", item.Name),
                item => Assert.Equal("Marketing", item.Name));

        }

        [Fact(DisplayName = "Test method Get Employer by id")]
        [Trait("Categoria", "EmployerController")]
        public async Task EmployerController_WhenIDoRequestById_MustReturnEmployer()
        {
            // Arrante
            var employerController = GeEmployerContraller();
            Mock<IGetEmployerByIdUseCaseAsync> _useCaseAsync = new Mock<IGetEmployerByIdUseCaseAsync>();
            var response = new EmployerEntity() { Id = 1, IdDepartament = 12, Name = "TI" };
            _useCaseAsync.Setup(x => x.RunAsync(1)).ReturnsAsync(response);
            var result = await employerController.GetEmployerById(_useCaseAsync.Object, 1);

            // Act
            var objectResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var resultResponse = objectResult.Value.Should().BeAssignableTo<EmployerEntity>().Subject;

            // Assert
            resultResponse.Should().Be(response, "Return employer success");
        }

        [Fact(DisplayName = "Insert Employer")]
        [Trait("Categoria", "EmployerController")]
        public async Task EmployerController_WhenInInsertEmployer_MustReturnValueOne()
        {
            // Arrange
            var employerController = GeEmployerContraller();
            Mock<IInsertEmployerUseCaseAsync> _useCaseAsync = new Mock<IInsertEmployerUseCaseAsync>();
            var request = new EmployerRequest() { IdDepartment = 1, Name = "Business" };
            _useCaseAsync.Setup(x => x.RunAsync(request)).ReturnsAsync(1);
            var result = await employerController.PostAsync(_useCaseAsync.Object, request);

            // Act
            var objectResult = result.Should().BeOfType<OkObjectResult>().Subject;

            // Assert
            Assert.Equal(1, objectResult.Value);
        }

        [Fact(DisplayName = "Delete Employer")]
        [Trait("Categoria", "EmployerController")]
        public async Task EmployerController_WhenInInsertEmployerId_MustDeleteEmployer()
        {
            // Arrange
            var employerController = GeEmployerContraller();
            Mock<IDeleteEmployerUseCaseAsync> _useCaseAsync = new Mock<IDeleteEmployerUseCaseAsync>();
            _useCaseAsync.Setup(x => x.RunAsync(11)).ReturnsAsync(1);
            var result = await employerController.DeleteAsync(_useCaseAsync.Object, 11);

            // Act
            var objectResult = result.Should().BeOfType<OkObjectResult>().Subject;

            // Assert
            Assert.Equal(1, objectResult.Value);
        }

        [Fact(DisplayName = "Update Epmployer")]
        [Trait("Categoria", "EmployerController")]
        public async Task EmployerController_WhenUpdateEmployer_MustRurnTrue()
        {
            // Arrange
            var employerController = GeEmployerContraller();
            Mock<IUpdateEmployerUseCaseAsync> _useCaseAsync = new Mock<IUpdateEmployerUseCaseAsync>();
            var request = new EmployerEntity { Id = 1, IdDepartament = 12, Name = "TI" };
            var response = GetResponse();
            _useCaseAsync.Setup(r => r.RunAsync(request)).ReturnsAsync(response);
            var result = await employerController.UpdateAsync(_useCaseAsync.Object, request);


            // Act
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var employerEntity = okResult.Value.Should().BeAssignableTo<ResultResponse>().Subject;

            // Assert
            employerEntity.Should().Be(response, "Update success");
        }

        private IEnumerable<EmployerEntity> GetListEmployer()
        {
            return new List<EmployerEntity>
            {
              new EmployerEntity {Id = 1, IdDepartament = 12, Name = "TI"},
              new EmployerEntity {Id = 2, IdDepartament = 2, Name = "Business"},
              new EmployerEntity {Id = 3, IdDepartament = 31, Name = "Management"},
              new EmployerEntity {Id = 4, IdDepartament = 6, Name = "Marketing"}
            };
        }

        private EmployerController GeEmployerContraller()
        {
            return new EmployerController(_logger.Object, _notificationMessages.Object);
        }

        private ResultResponse GetResponse()
        {
            return new ResultResponse
            {
                Data = new EmployerEntity { Id = 1, IdDepartament = 12, Name = "TI" },
                Message = "Update success",
                Success = true
            };
        }
    }
}

