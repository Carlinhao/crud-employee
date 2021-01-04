using employers.domain.Entities.UserAuth;
using employers.domain.UserAuth;
using System.Threading.Tasks;

namespace employers.domain.Interfaces.Repositories.UserAuth
{
    public interface IUserAuthRepository
    {
        Task<UserEntity> ValidateCredentials(UserInfoRequest userInfoRequest);
        Task<UserEntity> RefresUserInfo(UserEntity request);
    }
}
