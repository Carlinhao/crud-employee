using employers.application.UseCases.Departament;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace employer.application.tests.UseCases.Department
{
    public class GetDepartamentUseCaseAsyncTest
    {
        private readonly Mock<IDepartmentRepository> _departmentRepository;

        public GetDepartamentUseCaseAsyncTest()
        {
            _departmentRepository = new Mock<IDepartmentRepository>();
        }

        [Fact(DisplayName = "Get all department")]
        [Trait("Category", "Department")]
        public async Task GetDepartamentUseCaseAsync_WhenCall_MustReturnAllDepartment()
        {
            // Arrange
            var department = GetDepartment();
            var useCase = new GetDepartamentUseCaseAsync(_departmentRepository.Object);
            _departmentRepository.Setup(r => r.GetAll()).ReturnsAsync(department);

            // Act
            var result = await useCase.RunAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result, 
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(2, item.Id),
                item => Assert.Equal(3, item.Id),
                item => Assert.Equal(4, item.Id),
                item => Assert.Equal(7, item.Id));
        }

        private IEnumerable<DepartmentEntity> GetDepartment()
        {
            return new List<DepartmentEntity>
            {
                new DepartmentEntity { Id = 1, Name = "TI"},
                new DepartmentEntity { Id = 2, Name = "Sales"},
                new DepartmentEntity { Id = 3, Name = "Business"},
                new DepartmentEntity { Id = 4, Name = "Medical"},
                new DepartmentEntity { Id = 7, Name = "Marketing"},
            };
        }
    }
}
