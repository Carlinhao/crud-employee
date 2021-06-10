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
            var useCase = new InsertOccupationUseCaseAsync(_repository.Object);
            _repository.Setup(x => x.InsertAsync(new OccupationRequest())).ReturnsAsync(new ResultResponse());

            // Act
            var result = await useCase.RunAsync(new OccupationRequest());

            // Assert
            Assert.NotNull(result);
            Assert.True(result is ResultResponse);
        }

        private OccupationRequest GetOccupationRequest()
        {
            return new OccupationRequest { LevelOccupation = "Sr.", NameOccupation = "Developer" };
        }
    }
