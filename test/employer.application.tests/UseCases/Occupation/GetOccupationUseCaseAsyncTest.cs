using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Responses;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Occupation
{
    public class GetOccupationUseCaseAsyncTest
    {
        private readonly Mock<IOccupationRepository> _repository;

        public GetOccupationUseCaseAsyncTest()
        {
            _repository = new Mock<IOccupationRepository>();
        }

        [Fact(DisplayName = "Return a list of Occupation")]
        [Trait("Categoria", "Occupation")]
        public async Task GetOccupationUseCaseAsync_RunAsync_MsutReturnAllOccupation()
        {
            // Arrange
            var useCase = new GetOccupationUseCaseAsync(_repository.Object);
            var response = GetAllOccupation();

            // Act
            _repository.Setup(x => x.GetAllAsync()).ReturnsAsync(response);
            var result = await useCase.RunAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is ResultResponse);
        }

        private ResultResponse GetAllOccupation()
        {
            return new ResultResponse { Data = null, Message = "List occupation", Success = true };
        }
    }
}
