using employers.application.Exceptions.RegraNegocio;
using employers.application.UseCases.Departament;
using employers.domain.Interfaces.Repositories.Departament;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Department
{
    public class GetDepartamentByIdUseCaseAsyncTest
    {
        private readonly Mock<IDepartmentRepository> _repository;

        public GetDepartamentByIdUseCaseAsyncTest()
        {
            _repository = new Mock<IDepartmentRepository>();
        }

        [Fact(DisplayName = "Testing invalid Id")]
        [Trait("Category", "Department")]
        public async Task GetDepartamentByIdUseCaseAsync_WhenInvalidID_MustDisplayMessage()
        {
            // Arrange // Act
            var result = new GetDepartamentByIdUseCaseAsync(_repository.Object);                       

            // Assert
            var ex = await Assert.ThrowsAsync<RegranegocioException>(() => result.RunAsync(0));
            Assert.Equal("Invalid ID!", ex.Message);
        }
    }
}
