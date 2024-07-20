using System.Threading.Tasks;
using employers.api.Controllers.CreateUser;
using employers.application.Interfaces.UserAuth;
using employers.domain.Requests;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace employer.api.tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        [Trait("Category", "UserController")]
        public async Task InserUser_WhenDataIsvalid_MustReturnOkResult()
        {
            // Arrange
            int count = 1;
            var fakerUser = A.Fake<ICreateUserUseCaseAsync>();
            var fakerRequest = A.Fake<CreateUserRequest>();
            A.CallTo(() => fakerUser.RunAsync(fakerRequest)).Returns(count);

            var controller = new UserController(fakerUser);

            // Act
            var actionResult = await controller.InserUser(fakerRequest);
            var result = actionResult as OkObjectResult;

            // Assert
            var resultInteger = result.Value.Should().BeAssignableTo<int>().Subject;

            Assert.Equal(count, resultInteger);
        }
    }
}
