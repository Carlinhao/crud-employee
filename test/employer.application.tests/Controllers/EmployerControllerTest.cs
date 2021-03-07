﻿using employers.api.Controllers;
using employers.application.Interfaces.Empregado;
using employers.application.Notifications;
using employers.domain.Entities.Employer;
using employers.domain.Requests;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

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

            // Act
            useCase.Setup(x => x.RunAsync()).ReturnsAsync(response);
            var result = await employerController.GetAll(useCase.Object);

            // Assert
            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Test method Get Employer by id")]
        [Trait("Categoria", "EmployerController")]
        public async Task EmployerController_WhenIDoRequestById_MustReturnEmployer()
        {
            // Arrante
            var employerController = GeEmployerContraller();
            Mock<IGetEmployerByIdUseCaseAsync> _useCaseAsync = new Mock<IGetEmployerByIdUseCaseAsync>();
            var response = new EmployerEntity() { Id = 1, IdDepartament = 12, Name = "TI" };

            // Act
            _useCaseAsync.Setup(x => x.RunAsync(1)).ReturnsAsync(response);
            var result = await employerController.GetEmployerById(_useCaseAsync.Object, 1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Mudar")]
        [Trait("Categoria", "EmployerController")]
        public void EmployerController_WhenInInsertEmployer_MustReturnValueOne()
        {
            // Arrange
            var employerController = GeEmployerContraller();
            Mock<IInsertEmployerUseCaseAsync> _useCaseAsync = new Mock<IInsertEmployerUseCaseAsync>();
            var request = new EmployerRequest() { IdDepartment = 1, Name = "Business" }; 

            // Act
            _useCaseAsync.Setup(x => x.RunAsync(request)).ReturnsAsync(1);
            var result = employerController.PostAsync(_useCaseAsync.Object, request);

            // Assert
            Assert.NotNull(result);
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
    }
}
