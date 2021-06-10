using employers.application.UseCases.Occupation;
using employers.domain.Interfaces.Repositories.Occupation;
using Moq;
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
        public void InsertOccupationUseCaseAsync_RunAsync_MustInsertAnOccupation()
        {
            // Arrange
            

            // Act

            // Assert

        }
    }
}
