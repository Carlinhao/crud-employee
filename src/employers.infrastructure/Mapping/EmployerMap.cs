using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities.Employer;

namespace employers.infrastructure.Mapping
{
    public class EmployerMap : DommelEntityMap<EmployerEntity>
    {
        public EmployerMap()
        {
            ToTable("Empregado");

            Map(x => x.Id).ToColumn("ID_EMP").IsKey();
            Map(x => x.Name).ToColumn("NOM_EMP");
            Map(x => x.IdDepartament).ToColumn("ID_DPTO");
        }
    }
}
