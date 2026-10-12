using System.Collections.Generic;

namespace employers.domain.Entities.Employee;

public class EmployeeResponse
{
    public Pagination Pagination { get; set; }
    public IEnumerable<EmployeeEntity> Employees { get; set; }
}