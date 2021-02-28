using employers.domain.Entities.Employer;
using employers.domain.Interfaces.Repositories.Employers;
using employers.domain.Requests;
using Moq;
using System.Collections.Generic;

namespace employer.application.tests.Utils
{
    public class FluentMockEmployerRepository : Mock<IEmployerRepository>
    {
        public FluentMockEmployerRepository GetById(object id)
        {
            var response = new EmployerEntity { Id = 1, IdDepartament = 5, Name = "Paul Stone" };

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

        public IEnumerable<EmployerEntity> GetEmployers()
        {
            return new List<EmployerEntity>
            {
                new EmployerEntity { Id = 1, IdDepartament = 5, Name = "Paul Stone"},
                new EmployerEntity { Id = 2, IdDepartament = 8, Name = "Maria Rita"},
                new EmployerEntity { Id = 3, IdDepartament = 3, Name = "Lunna Iris"},
                new EmployerEntity { Id = 4, IdDepartament = 9, Name = "Lis Bela"},
            };
        }
    }
}
