using Dapper.FluentMap.Dommel.Mapping;
using employers.domain.Entities.UserAuth;

namespace employers.infrastructure.Mapping
{
    public class UserEntityMap : DommelEntityMap<UserEntity>
    {
        public UserEntityMap()
        {
            ToTable("User_Auth");

            Map(x => x.Id).ToColumn("ID_USER").IsKey();
            Map(x => x.UserName).ToColumn("NAME_USER");
            Map(x => x.FullName).ToColumn("FULL_NAME_USER");
            Map(x => x.Password).ToColumn("USER_PWD");
            Map(x => x.AcessToken).ToColumn("ACESS_TOKEN");
            Map(x => x.RefreshToken).ToColumn("REFRESH_TOKEN");
            Map(x => x.RefreshTokenExpire).ToColumn("REFRESH_TOKEN_EXPIRE");

        }
    }
}
