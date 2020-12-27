using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities.UserAuth;

namespace employers.infrastructure.Mapping
{
    public class UserMap : DommelEntityMap<UserEntity>
    {
        public UserMap()
        {
            ToTable("Users");

            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.FullName).ToColumn("USR_NAM");
            Map(x => x.UserName).ToColumn("Id");
            Map(x => x.Password).ToColumn("PWD");
            Map(x => x.AcessToken).ToColumn("RFH_TOK");
            Map(x => x.RefreshTokenExpire).ToColumn("RFH_TOK_EXP");
        }
    }
}