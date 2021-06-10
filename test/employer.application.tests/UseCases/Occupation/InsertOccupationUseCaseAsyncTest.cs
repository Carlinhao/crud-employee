using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Occupation
{
    public class InsertOccupationUseCaseAsyncTest
    {
        private readonly Mock<IOccupationRepository> _repository;

        public InsertOccupationUseCaseAsyncTest()
        {
            _repository = new Mock<IOccupationRepository>();
        }

        [Fact(DisplayName = "Mudar")]
        [Trait("Categoria", "Mudar")]
        public async Task InsertOccupationUseCaseAsync_RunAsync_MustInsertAnOccupation()
        {
            // Arrange
            var request = GetOccupationRequest();
            var response = GetResultResponse();
            var useCase = new InsertOccupationUseCaseAsync(_repository.Object);
            _repository.Setup(x => x.InsertAsync(request)).ReturnsAsync(response);

            // Act
            var result = await useCase.RunAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result is ResultResponse);
        }

        private OccupationRequest GetOccupationRequest()
        {
            return new OccupationRequest { LevelOccupation = "Sr.", NameOccupation = "Developer" };
        }

        private ResultResponse GetResultResponse()
        {
            var data = GetOccupationRequest();

            return new ResultResponse { Data = data, Message = "Insert with success", Success = true };
        }
    }
}