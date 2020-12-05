using AutoMapper;
using employers.application.Interfaces.UseCases.Departament;
using employers.domain.Entities;
using employers.domain.Interfaces.Repositories.Departament;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employers.application.UseCases.Departament
{
    public class GetDepartamentUseCaseAsync : IGetDepartamentUseCaseAsync
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IMapper _mapper;

        public GetDepartamentUseCaseAsync(IDepartamentRepository departamentRepository, IMapper mapper)
        {
            _departamentRepository = departamentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartamentEntity>> RunAsync()
        {

            var result = await _departamentRepository.GetAll();

            return result;
        }
    }
}
