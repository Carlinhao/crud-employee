using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using employers.domain.Requests;
using Moq;
using System.Collections.Generic;

namespace employer.repository.tests.FluentMockRepository
{
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
                new DepartmentEntity { Id = 1, Name = "TI"},
                new DepartmentEntity { Id = 2, Name = "Sales"},
                new DepartmentEntity { Id = 3, Name = "Business"},
                new DepartmentEntity { Id = 4, Name = "Medical"},
                new DepartmentEntity { Id = 7, Name = "Marketing"},
            };
        }
    }
}
