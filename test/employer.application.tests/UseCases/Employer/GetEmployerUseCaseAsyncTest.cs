using employers.application.UseCases.Employers;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories.Employers;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Employer
{
    public class GetEmployerUseCaseAsyncTest
    {
        private readonly Mock<IEmployerRepository> _employerRepository;

        public GetEmployerUseCaseAsyncTest()
        {
            _employerRepository = new Mock<IEmployerRepository>();
        }

        [Fact(DisplayName = "Must return all Employer")]
        [Trait("Category", "Employer")]
        public async Task GetEmployerUseCaseAsync_WhenRequestSuccess_MustReturnAllEmployer()
        {
            // Arrange
            var useCase = new GetEmployerUseCaseAsync(_employerRepository.Object);
            var employer = GetEmployer();

            // Act
            _employerRepository.Setup(x => x.GetAll()).ReturnsAsync(employer);
            var result = await useCase.RunAsync();

            // Assert
            Assert.True(result.ToList().Count() == 4);

            Assert.Collection(result, 
                item => Assert.Equal("IT", item.Name),
                item => Assert.Equal("HR", item.Name),
                item => Assert.Equal("Business", item.Name),
                item => Assert.Equal("Manager", item.Name));
        }

        private IEnumerable<EmployeeEntity> GetEmployer()
        {
            var result = new List<EmployeeEntity>()
            {
                new EmployeeEntity { Id = 1, IdDepartament = 2, Name = "IT" },
                new EmployeeEntity { Id = 2, IdDepartament = 4, Name = "HR" },
                new EmployeeEntity { Id = 3, IdDepartament = 6, Name = "Business" },
                new EmployeeEntity { Id = 4, IdDepartament = 9, Name = "Manager" },
            };

            return result;
        }
    }
}
