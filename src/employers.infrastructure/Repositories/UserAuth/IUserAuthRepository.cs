using employers.domain.Entities.UserAuth;
using employers.domain.UserAuth;
using System.Threading.Tasks;

namespace employers.infrastructure.Repositories.UserAuth
{
    public interface IUserAuthRepository
    {
        Task<UserEntity> ValidateCredentials(UserInfoRequest userInfoRequest);
    }
}
