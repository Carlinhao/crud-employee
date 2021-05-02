using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities;

namespace employers.infrastructure.Mapping
{
    public class DepartmentMap : DommelEntityMap<DepartmentEntity>
    {
        public DepartmentMap()
        {
            ToTable("Department");

            Map(x => x.Id).ToColumn("ID_DEPARTMENT").IsKey();
            Map(x => x.Name).ToColumn("NOM_DEPARTMENT");
            Map(x => x.Manager).ToColumn("MANAGER");
            Map(x => x.Description).ToColumn("DESC_DEPARTMENT");
        }
    }
}
