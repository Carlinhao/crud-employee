using System.Threading.Tasks;
using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using Moq;
using Xunit;

namespace employer.application.tests.UseCases.Occupation
{
    public class GetOccupationUseCaseAsyncTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetOccupationUseCaseAsyncTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact(DisplayName = "Return a list of Occupation")]
        [Trait("Categoria", "Occupation")]
        public async Task GetOccupationUseCaseAsync_RunAsync_MsutReturnAllOccupation()
        {
            // Arrange
            var useCase = new GetOccupationUseCaseAsync(_unitOfWork.Object);
            var response = GetAllOccupation();

            // Act
            _unitOfWork.Setup(x => x.OccupationRepository.GetAllAsync()).ReturnsAsync(response);
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
