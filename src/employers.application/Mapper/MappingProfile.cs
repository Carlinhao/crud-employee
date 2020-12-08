using AutoMapper;
using employers.domain.Entities;
using employers.domain.Responses;

namespace employers.application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentEntity, DepartamentResponse>();
        }
    }
}
