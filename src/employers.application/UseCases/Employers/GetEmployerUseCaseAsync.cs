using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using employers.application.Interfaces.Empregado;
using employers.domain.Entities;
using employers.domain.Entities.Employee;
using employers.domain.Interfaces.Repositories;

namespace employers.application.UseCases.Employers;

public class GetEmployerUseCaseAsync(IUnitOfWork unitOfWork) : IGetEmployerUseCaseAsync
{
    public async Task<IEnumerable<EmployeeEntity>> RunAsync(Pagination pagination, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.EmployerRepository.GetAll(pagination, cancellationToken);

        return result;
    }
}
