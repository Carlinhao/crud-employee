using AutoMapper;
using employers.domain.Entities;
using employers.domain.Entities.Employer;
using employers.domain.Responses;

namespace employers.application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartamentEntity, DepartamentResponse>();
            CreateMap<EmployerEntity, EmployerEntity>();
        }
    }
}
