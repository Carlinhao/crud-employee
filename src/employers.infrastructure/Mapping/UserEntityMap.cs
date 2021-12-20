using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities.UserAuth;

namespace employers.infrastructure.Mapping
{
    public class UserEntityMap : DommelEntityMap<UserEntity>
    {
        public UserEntityMap()
        {
            ToTable("User_Auth");

            Map(x => x.Password).ToColumn("USER_PWD").IsKey();
            Map(x => x.UserName).ToColumn("NAME_USER");
        }
    }
}
