using System;
using System.Threading.Tasks;
using employers.application.Interfaces.UserAuth;
using employers.domain.Interfaces.Repositories;
using employers.domain.Responses;
using employers.domain.Token;
using Microsoft.Extensions.Configuration;

namespace employers.application.UseCases.UserAuth;

public class UserAuthRefreshTokenUseCaseAsync(ITokenGenerate tokenGenerate,
                                              IUnitOfWork unitOfWork,
                                              IConfiguration configuration) : IUserAuthRefreshTokenUseCaseAsync
{
    private const string DATE_FORMATE = "yyyy-MM--dd HH:mm:ss";

    public async Task<TokenResponse> RunAsync(TokenResponse request)
    {
        var accessToken = request.AccessToken;
        var refreshToken = request.RefreshToken;
        var principal = await tokenGenerate.GetPrincipalFromExpiredToken(accessToken);

        var user = await unitOfWork.UserAuthRepository.ValidateCredentials(principal.Identity.Name);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpire <= DateTime.Now) return null;

        accessToken = await tokenGenerate.GenerateAccessToken(principal.Claims);
        refreshToken = await tokenGenerate.GenerateRefreshToken();

        user.RefreshToken = refreshToken;

        await unitOfWork.UserAuthRepository.RefresUserInfo(user);

        var createDate = DateTime.Now;
        var expireDate = createDate.AddMinutes(Convert.ToDouble(configuration.GetSection("TokenExtensions:Minutes").Value));


        return new TokenResponse
        {
            Authenticated = true,
            AccessToken = accessToken,
            Created = createDate.ToString(DATE_FORMATE),
            Expiration = expireDate.ToString(),
            RefreshToken = refreshToken
        };
    }
}
