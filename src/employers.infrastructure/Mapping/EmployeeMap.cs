using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities.Employer;

namespace employers.infrastructure.Mapping
{
    public class EmployeeMap : DommelEntityMap<EmployeeEntity>
    {
        public EmployeeMap()
        {
            ToTable("Employee");

            Map(x => x.Id).ToColumn("ID_EMPLOYEE").IsKey();
            Map(x => x.Name).ToColumn("NOM_EMPLOYEE");
            Map(x => x.Active).ToColumn("ACTIVE");
            Map(x => x.IdDepartament).ToColumn("ID_DEPARTMENT");
            Map(x => x.IdOccupation).ToColumn("ID_OCCUPATION");
        }
    }
}
