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
    public async Task<EmployeeResponse> RunAsync(Pagination pagination, CancellationToken cancellationToken)
        =>  await unitOfWork.EmployerRepository.GetAll(pagination, cancellationToken);
}
