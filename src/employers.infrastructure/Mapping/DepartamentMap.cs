using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities;

namespace employers.infrastructure.Mapping
{
    public class DepartamentMap : DommelEntityMap<DepartmentEntity>
    {
        public DepartamentMap()
        {
            ToTable("Departamento");

            Map(x => x.Id).ToColumn("ID_DPTO").IsKey();
            Map(x => x.Name).ToColumn("NOM_DPTO");
        }
    }
}
