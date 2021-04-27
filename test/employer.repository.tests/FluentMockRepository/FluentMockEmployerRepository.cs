using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using employers.domain.Responses;
using Moq;
using System.Collections.Generic;

namespace employer.repository.tests.FluentMockRepository
{
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

            Setup(x => x.GetAll()).ReturnsAsync(response);
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

            return new ResultResponse
            {
                Data = data,
                Message = "",
                Success = true
            };
        }

        public IEnumerable<EmployeeEntity> GetEmployers()
        {
            return new List<EmployeeEntity>
            {
                new EmployeeEntity { Id = 1, IdDepartament = 5, Name = "Paul Stone"},
                new EmployeeEntity { Id = 2, IdDepartament = 8, Name = "Maria Rita"},
                new EmployeeEntity { Id = 3, IdDepartament = 3, Name = "Lunna Iris"},
                new EmployeeEntity { Id = 4, IdDepartament = 9, Name = "Lis Bela"},
            };
        }
    }
}
