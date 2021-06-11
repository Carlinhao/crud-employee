using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using employers.domain.Requests;
using employers.domain.Responses;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Occupation
{
    public class UpdateOccupationUseCaseAsyncTest
    {
        private readonly Mock<IOccupationRepository> _repository;

        public UpdateOccupationUseCaseAsyncTest()
        {
            _repository = new Mock<IOccupationRepository>();
        }

        [Fact(DisplayName = "Update Occupation")]
        [Trait("Categoria", "Occupation")]
        public async Task GetOccupationUseCaseAsync_RunAsync_MsutReturnAllOccupation()
        {
            // Arrange
            var useCase = new UpdateOccupationUseCaseAsync(_repository.Object);
            var response = GetResultResponse();
            var request = GetOccupationUpdateRequest();

            // Act
            _repository.Setup(x => x.UpdateAsync(request)).ReturnsAsync(response);

            var result = await useCase.RunAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result is ResultResponse);
        }

        private OccupationUpdateRequest GetOccupationUpdateRequest()
        {
            return new OccupationUpdateRequest { LevelOccupation = "Sr.", NameOccupation = "Developer", Id = 1 };
        }

        private ResultResponse GetResultResponse()
        {
            var data = GetOccupationUpdateRequest();

            return new ResultResponse { Data = data, Message = "Insert with success", Success = true };
        }
    }
}
