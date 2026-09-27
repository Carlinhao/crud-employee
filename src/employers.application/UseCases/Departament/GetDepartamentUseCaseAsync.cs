using employers.application.Interfaces.Departament;
using employers.domain.Entities.Departament;
using employers.domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament;

public class GetDepartamentUseCaseAsync(IUnitOfWork unitOfWork) : IGetDepartamentUseCaseAsync
{
    public async Task<IEnumerable<DepartmentEntity>> RunAsync()
    {
        var result = await unitOfWork.DepartmentRepository.GetAll();

        return result;
    }
}
