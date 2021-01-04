using employers.domain.Responses;
using employers.domain.UserAuth;

namespace employers.application.Interfaces.UserAuth
{
    public interface IUserAuthUseCaseAsync : 
        IRestRequestAsync<TokenResponse, UserInfoRequest>
    {
    }
}
