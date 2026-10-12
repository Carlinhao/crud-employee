using employers.domain.Entities;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using employers.domain.Responses;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace employer.repository.tests.FluentMockRepository;

public class FluentMockEmployerRepository : Mock<IEmployerRepository>
{
    public FluentMockEmployerRepository GetById(object id)
    {
        var response = new EmployeeEntity { Id = 1, IdDepartament = 5, Name = "Paul Stone" };

        Setup(x => x.GetById(id)).ReturnsAsync(response);
        return this;
    }

    public FluentMockEmployerRepository GetAll()
    {
        var response = GetEmployers();

        Setup(x => x.GetAll(It.IsAny<Pagination>(), CancellationToken.None)).ReturnsAsync(response);
        return this;
    }

    public FluentMockEmployerRepository InsertAsync(EmployerRequest employerRequest)
    {
        Setup(x => x.InsertAsync(employerRequest)).ReturnsAsync(1);
        return this;
    }

    public FluentMockEmployerRepository DeleteAsync(int id)
    {
        Setup(x => x.DeleteAsync(id)).ReturnsAsync(1);
        return this;
    }

    public FluentMockEmployerRepository UpdateAsync(EmployeeEntity entity)
    {
        var response = GetInsertResponse();

        Setup(x => x.UpdateAsync(entity)).ReturnsAsync(response);
        return this;
    }

    public ResultResponse GetInsertResponse()
    {
        var data = new EmployeeEntity { Id = 1, IdDepartament = 5, Name = "Paul Stone" };

        return new ()
        {
            Data = data,
            Message = "",
            Success = true
        };
    }

    public EmployeeResponse GetEmployers()
        => new EmployeeResponse()
        {
            Employees = new List<EmployeeEntity>
            {
                new() { Id = 1, IdDepartament = 12, Name = "TI" },
                new() { Id = 2, IdDepartament = 2, Name = "Business" },
                new() { Id = 3, IdDepartament = 31, Name = "Management" },
                new() { Id = 4, IdDepartament = 6, Name = "Marketing" }
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
