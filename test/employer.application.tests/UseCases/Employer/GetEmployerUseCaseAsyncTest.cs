using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using employers.application.UseCases.Employers;
using employers.domain.Entities;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace employer.application.tests.UseCases.Employer;

public class GetEmployerUseCaseAsyncTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    public GetEmployerUseCaseAsyncTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
    }

    [Fact(DisplayName = "Must return all Employer")]
    [Trait("Category", "Employer")]
    public async Task GetEmployerUseCaseAsync_WhenRequestSuccess_MustReturnAllEmployer()
    {
        // Arrange
        var useCase = new GetEmployerUseCaseAsync(_unitOfWork.Object);
        var employer = GetEmployer();

        // Act
        _unitOfWork.Setup(x => x.EmployerRepository.GetAll(It.IsAny<Pagination>(), CancellationToken.None)).ReturnsAsync(employer);
        var result = await useCase.RunAsync(It.IsAny<Pagination>(), CancellationToken.None);

        // Assert
        Assert.Equal(4, result.Employees.Count());

        Assert.Collection(result.Employees, 
            item => Assert.Equal("IT", item.Name),
            item => Assert.Equal("HR", item.Name),
            item => Assert.Equal("Business", item.Name),
            item => Assert.Equal("Manager", item.Name));
    }

    private EmployeeResponse GetEmployer()
        => new EmployeeResponse()
        {
            Employees = new List<EmployeeEntity>
            {
                new() { Id = 1, IdDepartament = 12, Name = "IT" },
                new() { Id = 2, IdDepartament = 2, Name = "HR" },
                new() { Id = 3, IdDepartament = 31, Name = "Business" },
                new() { Id = 4, IdDepartament = 6, Name = "Manager" }
            },
            Pagination = new Pagination()
            {
                TotalCount = 49,
                TotalPages = 5,
                PageNumber = 1,
                PageSize = 5
            }
        };
}
