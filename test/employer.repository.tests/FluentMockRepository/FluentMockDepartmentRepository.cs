using employers.domain.Entities.Departament;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using Moq;
using System.Collections.Generic;

namespace employer.repository.tests.FluentMockRepository;

public class FluentMockDepartmentRepository : Mock<IDepartmentRepository>
{
    public FluentMockDepartmentRepository GetAll()
    {
        var response = GetAllDepartment();

        Setup(x => x.GetAll()).ReturnsAsync(response);
        return this;
    }

    public FluentMockDepartmentRepository GetById(object id)
    {
        var response = new DepartmentEntity { Id = 1, Name = "TI" };

        Setup(x => x.GetById(id)).ReturnsAsync(response);
        return this;
    }

    public FluentMockDepartmentRepository InsertAsync(DepartmentRequest request)
    {
        Setup(x => x.InsertAsync(request)).ReturnsAsync(1);

        return this;
    }

    public IEnumerable<DepartmentEntity> GetAllDepartment()
    {
        return new List<DepartmentEntity>
        {
            new() { Id = 1, Name = "TI"},
            new() { Id = 2, Name = "Sales"},
            new() { Id = 3, Name = "Business"},
            new() { Id = 4, Name = "Medical"},
            new() { Id = 7, Name = "Marketing"},
        };
    }
}
