using employers.application.Interfaces.UserAuth;
using employers.domain.Interfaces.Repositories.UserAuth;
using employers.domain.Responses;
using employers.domain.Token;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace employers.application.UseCases.UserAuth
{
    public class UserAuthRefreshTokenUseCaseAsync : IUserAuthRefreshTokenUseCaseAsync
    {
        private const string DATE_FORMATE = "yyyy-MM--dd HH:mm:ss";

        private readonly ITokenGenerate _tokenGenerate;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IConfiguration _configuration;

        public UserAuthRefreshTokenUseCaseAsync(
            ITokenGenerate tokenGenerate, 
            IUserAuthRepository userAuthRepository, 
            IConfiguration configuration)
        {
            _tokenGenerate = tokenGenerate;
            _userAuthRepository = userAuthRepository;
            _configuration = configuration;
        }

        public async Task<TokenResponse> RunAsync(TokenResponse request)
        {
            var accessToken = request.AccessToken;
            var refreshToken = request.RefreshToken;

            var principal = await _tokenGenerate.GetPrincipalFromExpiredToken(accessToken);
            var userName = principal.Identity.Name;
            var user = await _userAuthRepository.ValidateCredentials(userName);

            if (user == null || 
                user.RefreshToken != refreshToken || 
                user.RefreshTokenExpire <= DateTime.Now) return null;

            accessToken = await _tokenGenerate.GenerateAccessToken(principal.Claims);

            refreshToken = await _tokenGenerate.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _userAuthRepository.RefresUserInfo(user);

            var createDate = DateTime.Now;
            var expireDate = createDate.AddMinutes(Convert.ToDouble(_configuration.GetSection("TokenExtensions:Minutes").Value));


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
}
