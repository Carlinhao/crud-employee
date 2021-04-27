using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities.Occupation;

namespace employers.infrastructure.Mapping
{
    public class OccupationEntityMap : DommelEntityMap<OccupationEntity>
    {
        public OccupationEntityMap()
        {  
            ToTable("Occupation");
            Map(x => x.Id).ToColumn("ID_OCCUPATION").IsKey();
            Map(x => x.LevelOccupation).ToColumn("LEVEL_OCCUPATION");
            Map(x => x.NameOccupation).ToColumn("NOM_OCCUPATION");        
        }
    }
}
