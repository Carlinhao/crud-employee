using employers.domain.Responses;

namespace employers.application.Interfaces.UserAuth
{
    public interface IUserAuthRefreshTokenUseCaseAsync :
        IRestRequestAsync<TokenResponse, TokenResponse>
    {
    }
}
