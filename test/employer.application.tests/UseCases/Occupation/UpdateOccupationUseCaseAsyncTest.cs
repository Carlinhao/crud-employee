using System.Threading.Tasks;
using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Requests;
using employers.domain.Responses;
using Moq;
using Xunit;

namespace employer.application.tests.UseCases.Occupation
{
    public class UpdateOccupationUseCaseAsyncTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public UpdateOccupationUseCaseAsyncTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact(DisplayName = "Update Occupation")]
        [Trait("Categoria", "Occupation")]
        public async Task GetOccupationUseCaseAsync_RunAsync_MsutReturnAllOccupation()
        {
            // Arrange
            var useCase = new UpdateOccupationUseCaseAsync(_unitOfWork.Object);
            var response = GetResultResponse();
            var request = GetOccupationUpdateRequest();

            // Act
            _unitOfWork.Setup(x => x.OccupationRepository.UpdateAsync(request)).ReturnsAsync(response);

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
