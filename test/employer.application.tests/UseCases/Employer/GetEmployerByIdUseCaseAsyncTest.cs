﻿using employers.application.Notifications;
using employers.application.UseCases.Employers;
using employers.domain.Interfaces.Repositories.Employers;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Employer
{
    public class GetEmployerByIdUseCaseAsyncTest
    {
        private readonly Mock<IEmployerRepository> _employerRepository;
        private readonly Mock<INotificationMessages> _notification;

        public GetEmployerByIdUseCaseAsyncTest()
        {
            _employerRepository = new Mock<IEmployerRepository>();
            _notification = new Mock<INotificationMessages>();
        }

        [Fact(DisplayName = "Testing invalid Id")]
        [Trait("Category", "Employer")]
        public async Task GetEmployerByIdUseCaseAsync_WhenInvalidID_MustDisplayMessage()
        {
            // Arrange 
            var useCase = new GetEmployerByIdUseCaseAsync(_employerRepository.Object, _notification.Object);

            // Act
            await useCase.RunAsync(0);

            // Assert
            _notification.Verify(x => x.AddNotification("GetEmployerByIdUseCaseAsync", "Invalid ID!", HttpStatusCode.BadRequest), Times.Once);
        }
    }
}
