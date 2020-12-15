using employers.application.Exceptions.RegraNegocio;
using employers.application.UseCases.Employers;
using employers.domain.Interfaces.Repositories.Employers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Employer
{
    public class GetEmployerByIdUseCaseAsyncTest
    {
        private readonly Mock<IEmployerRepository> _employerRepository;

        public GetEmployerByIdUseCaseAsyncTest()
        {
            _employerRepository = new Mock<IEmployerRepository>();
        }

        [Fact(DisplayName = "Testing invalid Id")]
        [Trait("Category", "Employer")]
        public async Task GetEmployerByIdUseCaseAsync_WhenInvalidID_MustDisplayMessage()
        {
            // Arrange // Act
            var useCase = new GetEmployerByIdUseCaseAsync(_employerRepository.Object);

            // Assert
            var ex = await Assert.ThrowsAsync<RegranegocioException>(() => useCase.RunAsync(0));
            Assert.Equal("Invalid ID!", ex.Message);
        }
    }
}
