using employers.application.Exceptions.RegraNegocio;
using employers.application.Interfaces.Departament;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class GetDepartamentByIdUseCaseAsync : IGetDepartamentByIdUseCaseAsync
    {
        private readonly IDepartamentRepository _departamentRepository;

        public GetDepartamentByIdUseCaseAsync(
            IDepartamentRepository departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }

        public async Task<DepartamentEntity> RunAsync(int id)
        {
            if (id <= 0)
                throw new RegranegocioException("Id inválido.");

            var result = await _departamentRepository.GetById(id);

            return result;
        }
    }
}
